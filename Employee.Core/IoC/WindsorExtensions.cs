using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.ComponentActivator;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Reflection;

namespace Employee.Core.IoC
{
    /// <summary>
    /// Расширения для IoC-контейнера
    /// </summary>
    public static class WindsorExtensions
    {
        
        /// <summary>Зарегистрировать имплементацию как Transient</summary>
        /// <typeparam name="TService">Интерфейс</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterTransient<TService, TImpl>(this IWindsorContainer container, string name = null)
            where TService : class
            where TImpl : TService
        {
            Component
                .For<TService>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleTransient()
                .RegisterIn(container);
        }

        /// <summary>Зарегистрировать имплементацию как Transient</summary>
        /// <typeparam name="TServiceOne">Интерфейс 1</typeparam>
        /// <typeparam name="TServiceTwo">Интерфейс 2</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterTransient<TServiceOne, TServiceTwo, TImpl>(this IWindsorContainer container, string name = null)
            where TServiceOne : class
            where TServiceTwo : class
            where TImpl : TServiceOne, TServiceTwo
        {
            Component
                .For<TServiceOne, TServiceTwo>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleTransient()
                .RegisterIn(container);
        }

        /// <summary>Зарегистрировать имплементацию как Transient</summary>
        /// <typeparam name="TServiceOne">Интерфейс 1</typeparam>
        /// <typeparam name="TServiceTwo">Интерфейс 2</typeparam>
        /// <typeparam name="TServiceThree">Интерфейс 3</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterTransient<TServiceOne, TServiceTwo, TServiceThree, TImpl>(this IWindsorContainer container, string name = null)
            where TServiceOne : class
            where TServiceTwo : class
            where TServiceThree : class
            where TImpl : TServiceOne, TServiceTwo, TServiceThree
        {
            Component
                .For<TServiceOne, TServiceTwo, TServiceThree>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleTransient()
                .RegisterIn(container);
        }

        /// <summary>Зарегистрировать имплементацию как Singleton</summary>
        /// <typeparam name="TService">Интерфейс</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterSingleton<TService, TImpl>(this IWindsorContainer container, string name = null)
            where TService : class
            where TImpl : TService
        {
            Component
                .For<TService>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleSingleton()
                .RegisterIn(container);
        }

        /// <summary>Зарегистрировать имплементацию как Singleton</summary>
        /// <typeparam name="TServiceOne">Интерфейс 1</typeparam>
        /// <typeparam name="TServiceTwo">Интерфейс 2</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterSingleton<TServiceOne, TServiceTwo, TImpl>(this IWindsorContainer container, string name = null)
            where TServiceOne : class
            where TServiceTwo : class
            where TImpl : TServiceOne, TServiceTwo
        {
            Component
                .For<TServiceOne, TServiceTwo>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleSingleton()
                .RegisterIn(container);
        }

        /// <summary>
        /// Регистрация компонента в контейнере
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="container"></param>
        public static void RegisterIn(this IRegistration registration, IWindsorContainer container)
        {
            if (registration == null)
            {
                throw new ArgumentNullException("registration");
            }

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Register(registration);
        }

        /// <summary>
        /// Регистрация компонента в контейнере
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="registration"></param>
        /// <param name="container"></param>
        public static void RegisterIn<T>(this ComponentRegistration<T> registration, IWindsorContainer container)
            where T : class
        {
            if (registration == null)
            {
                throw new ArgumentNullException("registration");
            }

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Register(registration);
        }

        /// <summary>
        /// Установка инсталлера в контейнере
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="container"></param>
        public static void InstallIn(this IWindsorInstaller installer, IWindsorContainer container)
        {
            if (installer == null)
            {
                throw new ArgumentNullException("installer");
            }

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Install(installer);
        }
        
        /// <summary>
        /// Возвращает истину, если указанный тип был зарегистрирован.
        /// </summary>
        /// <param name="container">
        /// Контейнер.
        /// </param>
        /// <typeparam name="T">
        /// Тип объекта.
        /// </typeparam>
        /// <returns></returns>
        public static bool HasComponent<T>(this IWindsorContainer container)
        {
            return container.Kernel.HasComponent(typeof(T));
        }

        /// <summary>
        /// Возвращает истину, если компонент с заданным именем был зарегистрирован.
        /// </summary>
        /// <param name="container">
        /// Контейнер.
        /// </param>
        /// <param name="key">
        /// Имя.
        /// </param>
        /// <returns></returns>
        public static bool HasComponent(this IWindsorContainer container, string key)
        {
            return container.Kernel.HasComponent(key);
        }

        /// <summary>
        /// Заполнение свойств объекта компонентами, зарегистрированными в контейнере
        /// </summary>
        /// <param name="container"> </param>
        /// <param name="target">
        /// The target. 
        /// </param>
        /// <exception cref="ComponentActivatorException">
        /// </exception>
        public static IWindsorContainer BuildUp(this IWindsorContainer container, object target)
        {
            var type = target.GetType();
            var kernel = container.Kernel;

            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanWrite && kernel.HasComponent(property.PropertyType))
                {
                    var value = kernel.Resolve(property.PropertyType);
                    try
                    {
                        property.SetValue(target, value, null);
                    }
                    catch (Exception ex)
                    {
                        var message = string.Format(
                            "Error setting property {0} on type {1}, See inner exception for more information.",
                            property.Name,
                            type.FullName);
#warning проверить правильность выброса исключения
                        throw new ComponentActivatorException(
                            message, ex, kernel.GetHandler(property.PropertyType).ComponentModel);
                    }
                }
            }

            return container;
        }

        /// <summary>
        /// Определение является ли коллекция генериком
        /// </summary>
        /// <param name="type">The type.</param>
        private static bool IsGenericCollection(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            return type
                .GetInterfaces()
                .Where(@interface => @interface.IsGenericType)
                .Any(@interface => @interface.GetGenericTypeDefinition() == typeof(ICollection<>));
        }

        /// <summary>
        /// Освобождение внедренных сервисов
        /// </summary>
        /// <param name="container"></param>
        /// <param name="objToConfigure"></param>
        public static void TearDown(this IWindsorContainer container, object objToConfigure)
        {
            // get all the properties through reflection
            var props = objToConfigure.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var info in props)
            {
                var o = info.GetValue(objToConfigure, null);
                if (o == null) continue;
                if (info.PropertyType.IsGenericCollection())
                {
                    var c = o as ICollection;
                    if (c != null)
                        foreach (var obj in c)
                            container.Release(obj);
                }
                else if ((info.PropertyType.IsInterface) || (info.PropertyType.IsClass))
                {
                    container.Release(o);
                }
            }
        }

        #region Using extensions to invoke action for resolved components

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        /// <param name="container"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <param name="arguments"></param>
        /// <param name="action"></param>
        public static void UsingForResolved(this IWindsorContainer container, Type serviceType, string key, object arguments, Action<IWindsorContainer, object> action)
        {
            var handler = container.Resolve(key, serviceType, arguments);
            HandlerActionInvoker(container, handler, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="key"></param>
        /// <param name="arguments"></param>
        /// <param name="action"></param>
        public static void UsingForResolved<T>(this IWindsorContainer container, string key, object arguments, Action<IWindsorContainer, T> action) where T : class
        {
            var handler = container.Resolve<T>(key, arguments);
            HandlerActionInvoker(container, handler, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        /// <param name="container"></param>
        /// <param name="serviceType"></param>
        /// <param name="arguments"></param>
        /// <param name="action"></param>
        public static void UsingForResolved(this IWindsorContainer container, Type serviceType, object arguments, Action<IWindsorContainer, object> action)
        {
            var handler = container.Resolve(serviceType, arguments);
            HandlerActionInvoker(container, handler, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="arguments"></param>
        /// <param name="action"></param>
        public static void UsingForResolved<T>(this IWindsorContainer container, object arguments, Action<IWindsorContainer, T> action) where T : class
        {
            var handler = container.Resolve<T>(arguments);
            HandlerActionInvoker(container, handler, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        public static void UsingForResolved<T>(this IWindsorContainer container, string key, Action<IWindsorContainer, T> action) where T : class
        {
            var handler = container.Resolve<T>(key);
            HandlerActionInvoker(container, handler, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        public static void UsingForResolved<T>(this IWindsorContainer container, Action<IWindsorContainer, T> action) where T : class
        {
            var handler = container.Resolve<T>();
            HandlerActionInvoker(container, handler, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        public static void UsingForResolvedAll(this IWindsorContainer container, Type serviceType, object arguments, Action<IWindsorContainer, object> action)
        {
            var handlers = (IEnumerable<object>)container.ResolveAll(serviceType, arguments);
            HandlersActionInvoker(container, handlers, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        public static void UsingForResolvedAll<T>(this IWindsorContainer container, object arguments, Action<IWindsorContainer, IEnumerable<T>> action) where T : class
        {
            var handlers = container.ResolveAll<T>(arguments);
            HandlersActionInvoker(container, handlers, action);
        }

        /// <summary>
        /// Метод расширение для обертки конструкции резрешения интерфейса, выполнения с реализацией действий и высвобождения ресурсов
        /// Использовать только для компонентов с жизненым циклом Transient
        /// </summary>
        public static void UsingForResolvedAll<T>(this IWindsorContainer container, Action<IWindsorContainer, IEnumerable<T>> action) where T : class
        {
            var handlers = container.ResolveAll<T>();
            HandlersActionInvoker(container, handlers, action);
        }

        private static void HandlerActionInvoker<T>(IWindsorContainer container, T handler, Action<IWindsorContainer, T> action) where T : class
        {
            try
            {
                action(container, handler);
            }
            finally
            {
                container.Release(handler);
            }
        }

        private static void HandlersActionInvoker<T>(IWindsorContainer container, IEnumerable<T> handlers, Action<IWindsorContainer, IEnumerable<T>> action) where T : class
        {
            try
            {
                action(container, handlers);
            }
            finally
            {
                foreach (var handler in handlers)
                {
                    container.Release(handler);
                }
            }
        }

        /// <summary>
        /// Возвращает IDisposable обертку, которая будет освобождать полученный компонент из контейнера
        /// </summary>
        /// <param name="container"><see cref="IWindsorContainer"/></param>
        /// <param name="components">Коллекция компонентов, полученных из контейнера</param>
        /// <returns>IDisposable</returns>
        public static IDisposable Using(this IWindsorContainer container, params object[] components)
        {
            return new DisposableWrapper(container, components);
        }
        #endregion
    }

    internal class DisposableWrapper : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly object[] _components;

        public DisposableWrapper(IWindsorContainer container, params object[] components)
        {
            _container = container;
            _components = components;
        }

        public void Dispose()
        {
            if (_components != null && _components.Any())
            {
                foreach (var component in _components)
                {
                    var cmps = component as IEnumerable;
                    if (cmps != null)
                    {
                        foreach (var cmp in cmps)
                        {
                            _container.Release(cmp);
                        }

                        continue;
                    }

                    if (component != null)
                    {
                        _container.Release(component);
                    }
                }
            }
        }
    }
}
