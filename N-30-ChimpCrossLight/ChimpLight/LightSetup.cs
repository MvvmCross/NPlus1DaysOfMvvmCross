using System.Reflection;
using Android.Content;
using Android.Views;
using ChimpLight.Bootstrap;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Binding.Droid;

namespace ChimpLight
{
    public class LightSetup
        : IMvxAndroidGlobals
    {
        public static readonly LightSetup Instance = new LightSetup();

        private LightSetup()
        {}

        public void EnsureInitialized(Context context)
        {
            if (MvxSimpleIoCContainer.Instance != null)
                return;

            ApplicationContext = context;

            MvxSimpleIoCContainer.Initialise();

            Mvx.RegisterSingleton<IMvxAndroidGlobals>(this);

            var plugin = new MvxFilePluginManager(".Droid", ".dll");
            Mvx.RegisterSingleton<IMvxPluginManager>(plugin);

            var builder = new MvxAndroidBindingBuilder();
            builder.DoRegistration();

            var viewCache = Mvx.Resolve<IMvxTypeCache<View>>();
            viewCache.AddAssembly(typeof(Android.Widget.LinearLayout).Assembly);

            var valueConverterRegistry = Mvx.Resolve<IMvxValueConverterRegistry>();
            valueConverterRegistry.AddOrOverwrite("TheLengthConverter", new LengthValueConverter());

            var locationBootstrap = new LocationPluginBootstrap();
            locationBootstrap.Run();
        }

        public string ExecutableNamespace { get { return "ChimpLight"; } }

        public Assembly ExecutableAssembly { get { return GetType().Assembly; } }

        public Context ApplicationContext { get; private set; }
    }
}