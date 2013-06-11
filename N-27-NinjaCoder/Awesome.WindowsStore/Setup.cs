// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.WindowsStore
{
    using Cirrious.MvvmCross.ViewModels;
    using Cirrious.MvvmCross.WindowsStore.Platform;

    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines the Setup type.
    /// </summary>
    public class Setup : MvxStoreSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="rootFrame">The root frame.</param>
        public Setup(Frame rootFrame)
            : base(rootFrame)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of IMvxApplication.</returns>
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}