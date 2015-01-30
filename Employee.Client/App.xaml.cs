using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Employee.Client.View;
using Employee.Client.Views;
using Employee.Core;
using Employee.Core.Config;
using Employee.Core.IoC;
using Employee.Core.Views;
using System;
using System.Windows;
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
        
        public IWindsorContainer Container
        {
            get
            {
                if (_theWindsorContainer == null)
                {
                    _theWindsorContainer = new WindsorContainer();
                }

                return _theWindsorContainer;
            }
        }

        public App()
        {
            InitializeApplication();
           
            RegisterConfigurationProvider();

            Configuration = LoadConfiguration();
        }

        private void InitializeApplication()
        {
            Component
                .For<IWindsorContainer>()
                .Instance(Container)
                .RegisterIn(Container);

            Container.Register(Component.For<IWindsorInstaller>().ImplementedBy<CoreInstaller>());

            foreach (var windsorInstaller in Container.ResolveAll<IWindsorInstaller>())
            {
                Container.Install(windsorInstaller);
                Container.Release(windsorInstaller);
            }

            Container.Register(Component.For<IShell<MainWindow>>().ImplementedBy<Shell>().LifestyleTransient());
            Container.Register(Component.For<MainWindow>().LifestyleTransient());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainProgram = Container.Resolve<IShell<MainWindow>>();
            mainProgram.Run();
            Container.Release(mainProgram);
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
