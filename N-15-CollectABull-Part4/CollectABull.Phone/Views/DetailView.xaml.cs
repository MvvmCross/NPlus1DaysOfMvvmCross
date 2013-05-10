using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using CollectABull.Core.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CollectABull.Phone.Views
{
    public partial class DetailView : MvxPhonePage
    {
        public DetailView()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            ((DetailViewModel)ViewModel).DeleteCommand.Execute(null);
        }
    }
}