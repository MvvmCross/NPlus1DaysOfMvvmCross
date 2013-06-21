using Android.Content;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using CustomBinding.Droid.Controls;

namespace CustomBinding.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<BinaryEdit>(
                            "N28", 
                            binary => new BinaryEditFooTargetBinding(binary) );
            base.FillTargetFactories(registry);
        }

        protected override System.Collections.Generic.IList<System.Reflection.Assembly> AndroidViewAssemblies
        {
            get
            {
                var toReturn = base.AndroidViewAssemblies;
                toReturn.Add(this.GetType().Assembly);
                return toReturn;
            }
        }
    }
}