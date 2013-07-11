using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Value.Phone.SampleData
{
    public class DesignTimeFirstViewModel
    {
        public DesignTimeFirstViewModel()
        {
            Foo = "I'm simple design time data";
        }

        public string Foo { get; set; }
    } 
}