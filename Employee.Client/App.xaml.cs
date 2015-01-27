using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Employee.Core;
using Employee.Core.Config;
using Employee.Core.Views;
using System;
using System.Windows;
using Employee.Core.ViewModels;
using Employee.Core.Windsor;

namespace Employee.Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>Объект конфигурации приложения</summary>
        public AppConfig Configuration { get; private set; }

        private volatile IWindsorContainer _theWindsorContainer;
        private object syncRoot = new Object();

        public IWindsorContainer Container
        {
            get
            {
                if (_theWindsorContainer == null)
                {
                    lock (syncRoot)
                    {
                        if (_theWindsorContainer == null)
                        {
                            _theWindsorContainer = new WindsorContainer().Install(FromAssembly.This());
                        }
                    }
                }

                return _theWindsorContainer;
            }
        }

        public App()
        {
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            Container.Register(Component.For<IWindsorInstaller>().ImplementedBy<CoreInstaller>());

            Container.Register(Component.For<IShell<MainWindow>>().ImplementedBy<Shell>().LifestyleTransient());
            Container.Register(Component.For<MainWindow>().LifestyleTransient());
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            RegisterConfigurationProvider();

            // загружаем конфигурацию
            Configuration = LoadConfiguration();

            var mainProgram = Container.Resolve<IShell<MainWindow>>();
            mainProgram.Run();

        }
        
        
        /// <summary>
        /// Регистрация провайдера конфигурации.
        /// По-умолчанию регистрируется <see cref="FileConfigProvider"/>,
        /// но при необходимости метод может быть переопределен в потомках <see cref="AppContext"/>
        /// </summary>
        protected virtual void RegisterConfigurationProvider()
        {
            Container.Register(Component.For<IConfigProvider>().ImplementedBy<FileConfigProvider>().LifestyleSingleton());
        }

        /// <summary>
        /// Загрузка конфгурации приложения
        /// </summary>
        /// <returns></returns>
        protected virtual AppConfig LoadConfiguration()
        {
            var provider = Container.Resolve<IConfigProvider>();
            if (provider == null)
                throw new InvalidOperationException("В системе не зарегистрировано ни одного провайдера конфигураций");

            return provider.GetConfig();
        }
    }
}
