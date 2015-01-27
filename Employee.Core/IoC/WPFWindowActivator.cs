using System.Linq;
using System.Reflection;
using System.Windows;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;
using Employee.Core.ViewModels;
using Employee.Core.Views;

namespace Employee.Core.Windsor
{
    public class WPFWindowActivator : DefaultComponentActivator
    {
        public WPFWindowActivator(ComponentModel model, IKernelInternal kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
            : base(model, kernel, onCreation, onDestruction)
        {
        }

        protected override object Instantiate(CreationContext context)
        {
            var candidate = SelectEligibleConstructor(context);

            // here dependencies are created
            var arguments = CreateConstructorArguments(candidate, context);

            // here proxy object (with interception) for component is created
            return CreateInstance(context, candidate, arguments);
        }

        protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
        {
            var component = base.CreateInstance(context, constructor, arguments);
            AssignViewModel(component, arguments);
            return component;
        }
        
        /// <summary>
        /// Find the first ctor argument that implements IViewModel.
        /// Assume it is the View Model and assign it to the component's
        /// DataContext property.
        /// </summary>
        /// <param name="component">The activated WPF element.</param>
        /// <param name="arguments">The constructor arguments</param>
        private void AssignViewModel(object component, object[] arguments)
        {
            var frameworkElement = component as FrameworkElement;
            if (frameworkElement == null || arguments == null)
            {
                return;
            }

            var vm = arguments.Where(a => a is IViewModel).FirstOrDefault();
            if (vm != null)
            {
                frameworkElement.DataContext = vm;
                AssignParentView(frameworkElement, vm);
            }
        }

        private void AssignParentView(FrameworkElement frameworkElement, object dataContext)
        {
            var view = frameworkElement as IView;
            if (view == null)
            {
                return;
            }

            var viewProp = dataContext.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && typeof(IView).IsAssignableFrom(p.PropertyType))
                .FirstOrDefault();
            if (viewProp != null)
            {
                viewProp.SetValue(dataContext, frameworkElement, null);
            }
        }

    }
}
