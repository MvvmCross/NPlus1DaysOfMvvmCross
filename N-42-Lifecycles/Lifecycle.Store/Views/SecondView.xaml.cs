using Cirrious.MvvmCross.WindowsStore.Views;
using Windows.UI.Xaml;

namespace Lifecycle.Store.Views
{
    public sealed partial class SecondView : MvxStorePage
    {
        public SecondView()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
