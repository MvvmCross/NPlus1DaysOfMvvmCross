// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.Wpf
{
    using System.Windows.Threading;

    using Cirrious.MvvmCross.ViewModels;
    using Cirrious.MvvmCross.Wpf.Platform;
    using Cirrious.MvvmCross.Wpf.Views;

    /// <summary>
    ///  Defines the Setup type.
    /// </summary>
    public class Setup : MvxWpfSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="dispatcher">The dispatcher.</param>
        /// <param name="presenter">The presenter.</param>
        public Setup(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher, presenter)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of MvxApplication</returns>
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
