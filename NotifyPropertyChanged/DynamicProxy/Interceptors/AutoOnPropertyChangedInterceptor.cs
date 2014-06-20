using Castle.DynamicProxy;

namespace NotifyPropertyChanged.DynamicProxy.Interceptors
{
    public class AutoOnPropertyChangedInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var viewModel = invocation.Proxy as ViewModelBase;
            if (viewModel == null)
                return;

            if (!invocation.Method.Name.StartsWith("set_"))
                return;

            var propertyName = invocation.Method.Name.Substring(4);
            viewModel.OnPropertyChanged(propertyName);
        }
    }
}