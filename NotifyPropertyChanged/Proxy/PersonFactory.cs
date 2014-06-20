using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace NotifyPropertyChanged.Proxy
{
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