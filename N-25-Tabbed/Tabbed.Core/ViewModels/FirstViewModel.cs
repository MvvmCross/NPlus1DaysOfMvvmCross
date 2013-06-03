using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Tabbed.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        public FirstViewModel()
        {
            Child1 = new Child1ViewModel();
            Child2 = new Child2ViewModel();
            Child3 = new Child3ViewModel();
        }
        private Child1ViewModel _child1;
        public Child1ViewModel Child1
        {
            get { return _child1; }
            set { _child1 = value; RaisePropertyChanged(() => Child1); }
        }

        private Child2ViewModel _child2;
        public Child2ViewModel Child2
        {
            get { return _child2; }
            set { _child2 = value; RaisePropertyChanged(() => Child2); }
        }

        private Child3ViewModel _child3;
        public Child3ViewModel Child3
        {
            get { return _child3; }
            set { _child3 = value; RaisePropertyChanged(() => Child3); }
        }
    }

    public class Child1ViewModel
    : MvxViewModel
    {
        private string _foo = "Hello Foo";
        public string Foo
        {
            get { return _foo; }
            set { _foo = value; RaisePropertyChanged(() => Foo); }
        }
        
        public ICommand GoCommand
        {
            get { return new MvxCommand(() => ShowViewModel<GrandChildViewModel>());}
        }
    }
    public class Child2ViewModel
    : MvxViewModel
    {
        private string _bar= @"Hello bar";
        public string Bar
        {
            get { return _bar; }
            set { _bar = value; RaisePropertyChanged(() => Bar); }
        }
        
    }
    public class Child3ViewModel
    : MvxViewModel
    {
        private string _oink = "42";
        public string Oink
        {
            get { return _oink; }
            set { _oink = value; RaisePropertyChanged(() => Oink); }
        }
        
    }
    public class GrandChildViewModel
        : MvxViewModel
    {
        private string _life = "heidi";
        public string Life
        {
            get { return _life; }
            set { _life = value; RaisePropertyChanged(() => Life); }
        }
    }
}
