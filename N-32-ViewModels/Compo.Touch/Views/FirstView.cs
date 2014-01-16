using System.ComponentModel;
using System.Drawing;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using Compo.Core.ViewModels;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Compo.Touch.Views
{
    public sealed class AddressUIView : MvxView
    {
        public AddressUIView()
        {
            BackgroundColor = UIColor.Green;

            var textFieldStreet = new UITextField(new RectangleF(10, 10, 320, 40));
            Add(textFieldStreet);
            var textFieldCity = new UITextField(new RectangleF(10, 50, 320, 40));
            Add(textFieldCity);
            var textFieldZipCode = new UITextField(new RectangleF(10, 90, 320, 40));
            Add(textFieldZipCode);

            this.DelayBind(() =>
                {
                    var set = this.CreateBindingSet<AddressUIView, AddressViewModel>();
                    set.Bind(textFieldStreet).To(vm => vm.StreetAddress);
                    set.Bind(textFieldCity).To(vm => vm.City);
                    set.Bind(textFieldZipCode).To(vm => vm.ZipCode);
                    set.Apply();
                });
        }    
    }

    public sealed class PersonView : MvxView
    {
        public PersonView()
        {
            BackgroundColor = UIColor.LightGray;

            var textFieldName = new UITextField(new RectangleF(10, 10, 320, 40));
            Add(textFieldName);
            var textFieldLastName = new UITextField(new RectangleF(10, 50, 320, 40));
            Add(textFieldLastName);

            var addressView = new AddressUIView();
            addressView.Frame = new RectangleF(10, 90, 320, 140);
            Add(addressView);

            var addressView2 = new AddressUIView();
            addressView2.Frame = new RectangleF(10, 250, 320, 140);
            addressView2.BackgroundColor = UIColor.Red;
            Add(addressView2);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PersonView, PersonViewModel>();
                set.Bind(textFieldName).To(vm => vm.FirstName);
                set.Bind(textFieldLastName).To(vm => vm.LastName);
                set.Bind(addressView).For(add => add.DataContext).To(vm => vm.HomeAddress);
                set.Bind(addressView2).For(add => add.DataContext).To(vm => vm.WorkAddress);
                set.Apply();
            });
        }        
    }

    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        protected FirstViewModel FirstViewModel
        {
            get { return ViewModel as FirstViewModel; }
        }

        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var table = new UITableView(new RectangleF(0, 0, 320, 720));
            Add(table);

            var source = new MvxStandardTableViewSource(table, "TitleText FirstName");
            table.Source = source;

            var currentPersonView = new PersonView();
            currentPersonView.Frame = new RectangleF(320, 10, 320, 900);
            Add(currentPersonView);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(source).To(vm => vm.People);
            set.Bind(source).For(s => s.SelectedItem).To(vm => vm.Current);
            set.Bind(currentPersonView).For(s => s.DataContext).To(vm => vm.Current);
            set.Apply();

            FirstViewModel.WeakSubscribe(ViewModelPropertyChanged);
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Current")
            {
                if (FirstViewModel.Current != null)
                {
                    OpenNewDisplay(FirstViewModel.Current);
                }
            }
        }

        private int _offsetX = 600;
        private int _offsetY = 10;
        private void OpenNewDisplay(PersonViewModel current)
        {
            var personView = new PersonView();
            personView.Frame = new RectangleF(_offsetX, _offsetY, 320, 900);
            personView.DataContext = current;
            Add(personView);

            _offsetX += 40;
            _offsetY += 40;
        }
    }
}