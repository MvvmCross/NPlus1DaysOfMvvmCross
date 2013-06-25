using System;

namespace Acme.Plugin.Html.Droid
{
    public class DroidEncode : IEncode
    {
        public string Encode(string input)
        {
            return "DROID ENCODED: " + input;
        }
    }
}
