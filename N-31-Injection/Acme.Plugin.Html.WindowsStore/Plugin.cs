using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace Acme.Plugin.Html.WindowsStore
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterType<IEncode, StoreEncode>();
        }
    }
}