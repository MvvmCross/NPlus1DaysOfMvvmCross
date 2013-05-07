using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using KittensDb.Core.Services;

namespace KittensDb.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private string _filter = "";
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; RaisePropertyChanged(() => Filter); }
        }

        private List<Kitten> _kittens;
        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set { _kittens = value; RaisePropertyChanged(() => Kittens); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _applyFilterCommand;
        public System.Windows.Input.ICommand ApplyFilterCommand
        {
            get
            {
                _applyFilterCommand = _applyFilterCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoApplyFilter);
                return _applyFilterCommand;
            }
        }

        private void DoApplyFilter()
        {
            Kittens = _dataService.KittensMatching(Filter);
        }


        private int _totalCount;
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; RaisePropertyChanged(() => TotalCount); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _insertCommand;
        public System.Windows.Input.ICommand InsertCommand
        {
            get
            {
                _insertCommand = _insertCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoInsert);
                return _insertCommand;
            }
        }

        private int _countAdded = 0;

        private void DoInsert()
        {
            _countAdded++;
            var kitten = _kittenGenesisService.CreateNewKitten(_countAdded.ToString());
            _dataService.Insert(kitten);
            RefreshDataCount();
        }

        private void RefreshDataCount()
        {
            TotalCount = _dataService.Count;
        }

        private readonly IDataService _dataService;
        private readonly IKittenGenesisService _kittenGenesisService;

        public FirstViewModel(IDataService dataService, IKittenGenesisService kittenGenesisService)
        {
            _dataService = dataService;
            _kittenGenesisService = kittenGenesisService;
            RefreshDataCount();
            DoApplyFilter();
        }
    }
}
