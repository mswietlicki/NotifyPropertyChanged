using Castle.Core;

namespace NotifyPropertyChanged.Proxy
{
    public class Person : ViewModelBase
    {
        public Person()
        {
            RegisterPropertyDependecy(() => FirstName, () => FullName);
            RegisterPropertyDependecy(() => LastName, () => FullName);
        }
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
