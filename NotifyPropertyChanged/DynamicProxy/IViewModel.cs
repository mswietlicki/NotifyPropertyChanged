using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChanged.DynamicProxy
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}