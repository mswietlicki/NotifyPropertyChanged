using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChanged.BetterManual
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var propertyName = ((MemberExpression)projection.Body).Member.Name;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}