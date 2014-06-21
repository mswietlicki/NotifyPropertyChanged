using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NotifyPropertyChanged.DynamicProxy.Interceptors;

namespace NotifyPropertyChanged.DynamicProxy
{
    /// <summary>
    /// PersonFactory creates dynamic proxy of type Person. Proxy will listen to changes and invoke OnPropertyChanged on property set.
    /// </summary>
    public class PersonFactory
    {
        public Person CreatePerson()
        {
            using (var container = new WindsorContainer())
            {
                container.Register(
                    Component.For<IInterceptor>()
                        .ImplementedBy<AutoOnPropertyChangedInterceptor>());

                container.Register(
                    Component.For<Person>()
                        .ImplementedBy<Person>().Interceptors(InterceptorReference.ForType<IInterceptor>()).Anywhere);

                return container.Resolve<Person>(); 
            }
        }
    }
}