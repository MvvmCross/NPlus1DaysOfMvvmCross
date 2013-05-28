using System;
using Cirrious.MvvmCross.ViewModels;

namespace AndroidDemo.Core
{
	public class App : MvxApplication
	{
		public App ()
		{
		}

		public override void Initialize()
		{
			RegisterAppStart<FirstViewModel> ();
		}
	}

	public class FirstViewModel
		: MvxViewModel
	{
		private string _foo;
		public string Foo {
			get { return _foo; }
			set {
				_foo = value;
				RaisePropertyChanged (() => Foo);
			}
		}
	}
}

