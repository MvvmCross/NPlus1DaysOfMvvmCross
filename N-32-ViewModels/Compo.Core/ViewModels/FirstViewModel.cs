using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace Compo.Core.ViewModels
{
    public class AddressViewModel
        : MvxViewModel
    {
        private string _streetAddress;
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; RaisePropertyChanged(() => StreetAddress); }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; RaisePropertyChanged(() => ZipCode); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; RaisePropertyChanged(() => City); }
        }
        
    }
    public class PersonViewModel
        : MvxViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(() => FirstName); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); }
        }

        private AddressViewModel _homeAddress;
        public AddressViewModel HomeAddress
        {
            get { return _homeAddress; }
            set { _homeAddress = value; RaisePropertyChanged(() => HomeAddress); }
        }

        private AddressViewModel _workAddress;
        public AddressViewModel WorkAddress
        {
            get { return _workAddress; }
            set { _workAddress = value; RaisePropertyChanged(() => WorkAddress); }
        }
    }

    public class FirstViewModel 
		: MvxViewModel
    {
        private List<PersonViewModel> _people;
        public List<PersonViewModel> People
        {
            get { return _people; }
            set { _people = value; RaisePropertyChanged(() => People); }
        }

        private PersonViewModel _current;
        public PersonViewModel Current
        {
            get { return _current; }
            set { _current = value; RaisePropertyChanged(() => Current); }
        }

        public FirstViewModel()
        {
            var list = new List<PersonViewModel>();
            for (var i = 0; i < 10; i++)
            {
                var p = new PersonViewModel()
                    {
                        FirstName = "F" + i,
                        LastName = "L" + i,
                        HomeAddress = new AddressViewModel()
                            {
                                City = "C" + i,
                                StreetAddress = "S" + i,
                                ZipCode = "Z" + i
                            },
                        WorkAddress = new AddressViewModel()
                            {
                                City = "WC" + i,
                                StreetAddress = "WS" + i,
                                ZipCode = "WZ" + i
                            },
                    };
                list.Add(p);
            }

            People = list;
        }
    }
}
