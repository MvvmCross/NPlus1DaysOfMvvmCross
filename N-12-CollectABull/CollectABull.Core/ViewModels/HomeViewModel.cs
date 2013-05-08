using Cirrious.MvvmCross.ViewModels;
using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.ViewModels
{
    public class HomeViewModel 
		: MvxViewModel
    {
        private readonly ICollectionService _collectionService;

        public HomeViewModel(ICollectionService collectionService)
        {
            _collectionService = collectionService;
            UpdateLatest();
        }

        private void UpdateLatest()
        {
            Latest = _collectionService.Latest;
        }

        private CollectedItem _latest;
        public CollectedItem Latest
        {
            get { return _latest; }
            set { _latest = value; RaisePropertyChanged(() => Latest); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _addCommnad;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                _addCommnad = _addCommnad ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoAdd);
                return _addCommnad;
            }
        }

        private void DoAdd()
        {
            ShowViewModel<AddViewModel>();
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _listCommand;
        public System.Windows.Input.ICommand ListCommand
        {
            get
            {
                _listCommand = _listCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoList);
                return _listCommand;
            }
        }

        private void DoList()
        {
            ShowViewModel<ListViewModel>();
        }                
    }
}
