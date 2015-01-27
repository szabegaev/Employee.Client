using Castle.Windsor;
using Employee.Core.Views;
using Employee.Core.ViewModels;

namespace Employee.Core.Windsor
{
    public class WindsorViewFactory : IViewFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorViewFactory(IWindsorContainer container)
        {
            this._container = container;
        }

        public T CreateView<T>() where T : IView
        {
            return _container.Resolve<T>();
        }

        public T CreateView<T>(object argumentsAsAnonymousType) where T : IView
        {
            return _container.Resolve<T>(argumentsAsAnonymousType);
        }
    }
}
