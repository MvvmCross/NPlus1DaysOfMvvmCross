using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.ViewModels
{
    public class ListViewModel
        : MvxViewModel
    {
        private readonly ICollectionService _collectionService;
        private readonly MvxSubscriptionToken _collectionChangedToken;

        public ListViewModel(ICollectionService collectionService, IMvxMessenger messenger)
        {
            _collectionService = collectionService;
            ReloadList();
            _collectionChangedToken = messenger.Subscribe<CollectionChangedMessage>(OnCollectionChanged);
        }

        private void ReloadList()
        {
            Items = _collectionService.All();
        }

        private void OnCollectionChanged(CollectionChangedMessage message)
        {
            ReloadList();
        }

        private List<CollectedItem> _items;

        public List<CollectedItem> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }


        public ICommand ShowDetailCommand
        {
            get
            {
                return new MvxCommand<CollectedItem>(item => ShowViewModel<DetailViewModel>(new DetailViewModel.Nav() { Id= item.Id }));
            }
        }
    }
}
