namespace NotifyPropertyChanged.BetterManual
{
    /// <summary>
    /// Person class uses base class ViewModelBase to hide most of complexity but you still have to create backing-fields 
    /// </summary>
    public class Person : ViewModelBase
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(() => FullName); //Usisng Lambda expression allows us to remove dangerous string literals.
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(() => FullName);
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
