using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using KittenView.Core.Services;

namespace KittenView.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        public FirstViewModel(IKittenGenesisService service)
        {
            var newList = new List<Kitten>();
            for (var i = 0; i < 100; i++)
            {
                var newKitten = service.CreateNewKitten(i.ToString());
                newList.Add(newKitten);
            }

            Kittens = newList;
        }

        private List<Kitten> _kittens;
        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set { _kittens = value; RaisePropertyChanged(() => Kittens); }
        }
    }
}
