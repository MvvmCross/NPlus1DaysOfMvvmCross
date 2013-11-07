using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Lifecycle.Core.ViewModels;

namespace Lifecycle.Wp.Views
{
    public abstract class BaseView : MvxPhonePage
    {
        protected IVisible VisibleViewModel
        {
            get { return base.ViewModel as IVisible; }
        }

        protected IKillable KillableViewModel
        {
            get { return base.ViewModel as IKillable; }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            VisibleViewModel.IsVisible(true);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            VisibleViewModel.IsVisible(false);
            if (e.NavigationMode == NavigationMode.Back)
                KillableViewModel.KillMe();
        }
    }
    public partial class FirstView : BaseView
    {
        public FirstView()
        {
            InitializeComponent();
        }
    }
}