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
    public partial class ListView : MvxPhonePage
    {
        public ListView()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((ListViewModel) ViewModel).ShowDetailCommand.Execute(e.AddedItems[0]);
                ((ListBox) sender).SelectedIndex = -1;
            }
        }
    }
}