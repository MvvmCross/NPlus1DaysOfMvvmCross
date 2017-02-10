using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using ObjCRuntime;
using UIKit;
using Foundation;

namespace BindMe.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var textFieldTitle = new UITextField(new CGRect(10, 10, 300, 30));
            Add(textFieldTitle);
            var picker = new UIPickerView();
            var pickerViewModel = new MvxPickerViewModel(picker);
            picker.Model = pickerViewModel;
            picker.ShowSelectionIndicator = true; 
            textFieldTitle.InputView = picker;

            var textFieldFirstName = new UITextField(new CGRect(10, 40, 300, 30));
            Add(textFieldFirstName);
            var textFieldLastName = new UITextField(new CGRect(10, 70, 300, 30));
            Add(textFieldLastName);
            var acceptedLabel = new UILabel(new CGRect(10, 100, 200, 30));
            acceptedLabel.Text = "Accepted?";
            Add(acceptedLabel);
            var accepted = new UISwitch(new CGRect(210, 100, 100, 30));
            Add(accepted);
            var add = new UIButton(UIButtonType.RoundedRect);
            add.SetTitle("Add", UIControlState.Normal);
            add.Frame = new CGRect(10,130,300,30);
            Add(add);
            var debugView = new UILabel(new CGRect(10, 130, 300, 30));
            Add(debugView);

            var table = new UITableView(new CGRect(10, 160, 300, 300));
            Add(table);
            var source = new MvxStandardTableViewSource(table, "TitleText FirstName");
            table.Source = source;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(textFieldFirstName).To(vm => vm.FirstName);
            set.Bind(textFieldLastName).To(vm => vm.LastName);
            set.Bind(pickerViewModel).For(p => p.ItemsSource).To(vm => vm.Titles);
            set.Bind(pickerViewModel).For(p => p.SelectedItem).To(vm => vm.Title);
            set.Bind(textFieldTitle).To(vm => vm.Title);
            set.Bind(accepted).To(vm => vm.Accepted);
            set.Bind(add).To(vm => vm.AddCommand);
            set.Bind(source).To(vm => vm.People);

            //set.Bind(debugView).To("If(Accepted, Format('{0} {1} ({2})', FirstName, LastName, Title), 'nada')");
            set.Bind(debugView).To("Strip(FirstName, 'S') + Strip(LastName,'S')");
            set.Apply();

            var tap = new UITapGestureRecognizer(() =>
                {
                    foreach (var view in View.Subviews)
                    {
                        var text = view as UITextField;
                        if (text != null)
                            text.ResignFirstResponder();
                    }
                });
            View.AddGestureRecognizer(tap);
        }
    }
}