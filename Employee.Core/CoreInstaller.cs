using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Employee.Core.ViewModels;
using Employee.Core.Views;
using Employee.Core.Windsor;
using System.IO;

namespace Employee.Core
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            try
            {
                container.AddFacility<TypedFactoryFacility>();

                container.Register(Component.For<IAbstructFactory>().AsFactory());
                

                container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                    .BasedOn<IView>()
                    .Configure(c => c.LifestyleTransient().Named(c.Implementation.Name))
                    .WithService.Base()
                    .WithService.FromInterface(typeof (IView)));

                container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                    .BasedOn<IViewModel>()
                    .Configure(c => c.LifestyleTransient().Named(c.Implementation.Name))
                    .WithService.Base()
                    .WithService.FromInterface(typeof (IViewModel)));

                container.Register(Component.For<IViewFactory>().AsFactory().LifestyleTransient());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error installing some components: " + ex.Message);
            }
        }

        static public string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;

                var uri = new UriBuilder(codeBase);

                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }
    }
}
