using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChanged.Proxy
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}