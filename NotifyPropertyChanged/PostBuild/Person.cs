using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;

namespace NotifyPropertyChanged.PostBuild
{
    /// <summary>
    /// This class uses PropertyChanged.Fody to implement INotifyPropertyChanged using post build IL modification. Manual implementaion of INotifyPropertyChanged is not needed but will help Visual Studio.
    /// </summary>
    [ImplementPropertyChanged]
    public class Person: INotifyPropertyChanged
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Fody is smart enough to know that FullName depends on FirstName and LastName and to invoke OnPropertyChanged("FullName")
        /// </summary>
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        /// <summary>
        /// Not really needed but will allow Visual Studio to see it.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
