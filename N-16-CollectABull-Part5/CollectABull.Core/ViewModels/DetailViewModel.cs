using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.ViewModels
{
    public class DetailViewModel
        : MvxViewModel
    {
        private readonly ICollectionService _collectionService;
        private CollectedItem _item;

        public DetailViewModel(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        public class Nav
        {
            public int Id { get; set; }
        }

        public void Init(Nav navigation)
        {
            Item = _collectionService.Get(navigation.Id);
        }

        public CollectedItem Item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged(() => Item); }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        _collectionService.Delete(Item);
                        Close(this);
                    });
            }
        }
    }
}