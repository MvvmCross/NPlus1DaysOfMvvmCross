using System;
using Cirrious.MvvmCross.ViewModels;

namespace MyApp.Core
{

	public class App : MvxApplication
	{
		public App ()
		{
		}

		public override void Initialize ()
		{
			RegisterAppStart<FirstViewModel>();
		}
	}
}

