using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;
using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.ViewModels
{
    public class ListViewModel
        : MvxViewModel
    {
        private readonly ICollectionService _collectionService;

        public ListViewModel(ICollectionService collectionService)
        {
            _collectionService = collectionService;
            Items = _collectionService.All();
        }

        private List<CollectedItem> _items;
        public List<CollectedItem> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }        
    }
}
