using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifyPropertyChanged.Manual;
using Xunit;

namespace NotifyPropertyChanged.Tests
{
    public class ManualImplementationTests
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
