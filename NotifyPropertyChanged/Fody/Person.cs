using PropertyChanged;

namespace NotifyPropertyChanged.Fody
{
    [ImplementPropertyChanged]
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
