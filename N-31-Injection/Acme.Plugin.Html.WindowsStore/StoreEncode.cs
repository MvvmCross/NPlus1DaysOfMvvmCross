using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Plugin.Html.WindowsStore
{
    public class StoreEncode : IEncode
    {
        public string Encode(string input)
        {
            return "Store encoded: " + input;
        }
    }
}
