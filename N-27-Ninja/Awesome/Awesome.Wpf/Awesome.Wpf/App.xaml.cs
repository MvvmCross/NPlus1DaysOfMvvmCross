// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Awesome.Wpf
{
    using System;

    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.ViewModels;
    using Cirrious.MvvmCross.Wpf.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Setup complete indicator.
        /// </summary>
        private bool setupComplete;

        /// <summary>
        /// Does the setup.
        /// </summary>
        private void DoSetup()
        {
            MvxSimpleWpfViewPresenter presenter = new MvxSimpleWpfViewPresenter(MainWindow);

            Setup setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            IMvxAppStart start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            this.setupComplete = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(EventArgs e)
        {
            if (!this.setupComplete)
            {
                this.DoSetup();
            }

            base.OnActivated(e);
        }
    }
}
