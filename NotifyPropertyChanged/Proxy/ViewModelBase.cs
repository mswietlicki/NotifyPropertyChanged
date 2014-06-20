using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChanged.Proxy
{
    public class ViewModelBase : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var propertyName = ((MemberExpression)projection.Body).Member.Name;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RegisterPropertyDependecy<T1, T2>(Expression<Func<T1>> source, Expression<Func<T2>> reactor)
        {
            var sourcePropertyName = ((MemberExpression)source.Body).Member.Name;
            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(sourcePropertyName))
                    OnPropertyChanged(reactor);
            };
        }
    }
}