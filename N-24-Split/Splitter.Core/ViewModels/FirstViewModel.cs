using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Splitter.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        public ICommand BlueCommand
        {
            get { return new MvxCommand(() => ShowViewModel<BlueViewModel>());}
        }
        public ICommand RedCommand
        {
            get { return new MvxCommand(() => ShowViewModel<RedViewModel>()); }
        }
    }

    public class BlueViewModel : MvxViewModel
    {
    }

    public class RedViewModel : MvxViewModel
    {
    }
}
