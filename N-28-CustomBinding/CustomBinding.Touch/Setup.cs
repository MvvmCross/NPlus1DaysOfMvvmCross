using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using CustomBinding.Touch.Views;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;

namespace CustomBinding.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App();
		}

        protected override void FillBindingNames(Cirrious.MvvmCross.Binding.BindingContext.IMvxBindingNameRegistry registry)
        {
            // use these to register default binding names
            //registry.AddOrOverwrite<NicerBinaryEdit>(be => be.MyCount);
            //registry.AddOrOverwrite(typeof(BinaryEdit),"N28Doofus");
            base.FillBindingNames(registry);
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<BinaryEdit>(
                            "N28Doofus",
                            binary => new BinaryEditFooTargetBinding(binary));
            base.FillTargetFactories(registry);
        }
    }
}