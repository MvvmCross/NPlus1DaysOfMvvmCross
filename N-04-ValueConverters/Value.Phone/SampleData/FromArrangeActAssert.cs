using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Value.Phone.SampleData
{
    public class DesignTimeFirstViewModel : ViewModel
    {
        public DesignTimeFirstViewModel()
        {
            Foo = "I'm design time data";
        }

        private string _foo;
        public string Foo
        {
            get { return _foo; }
            set { _foo = value; OnPropertyChanged("Foo"); }
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }

 
}