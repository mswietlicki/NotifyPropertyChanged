using NotifyPropertyChanged.BetterManual;
using Xunit;

namespace NotifyPropertyChanged.Tests
{
    public class BetterManualImplementationTests
    {
        [Fact]
        public void FirstNamePropertyChanged()
        {
            var firstNameChanged = false;
            var person = new Person();
            person.PropertyChanged += (sender, args) => { if (args.PropertyName == "FirstName") firstNameChanged = true; };

            person.FirstName = "Mateusz";

            Assert.True(firstNameChanged);
        }

        [Fact]
        public void FullNamePropertyChangedOnFirstNameChange()
        {
            var fullNameChanged = false;
            var person = new Person();
            person.PropertyChanged += (sender, args) => { if (args.PropertyName == "FullName") fullNameChanged = true; };

            person.FirstName = "Mateusz";

            Assert.True(fullNameChanged);
        }
    }
}