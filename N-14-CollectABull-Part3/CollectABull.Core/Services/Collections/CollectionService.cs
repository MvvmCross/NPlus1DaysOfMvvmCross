using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.Services.Collections
{
    public class CollectionService
        : ICollectionService
    {
        private readonly IRepository _repository;
        private readonly IMvxMessenger _messenger;

        public CollectionService(IRepository repository, IMvxMessenger messenger)
        {
            _repository = repository;
            _messenger = messenger;
        }

        public List<CollectedItem> All()
        {
            return _repository.All();
        }

        public void Add(CollectedItem item)
        {
            _repository.Add(item);
            _messenger.Publish(new CollectionChangedMessage(this));
        }

        public CollectedItem Latest
        {
            get
            {
                return _repository.Latest;
            }
        }
    }
}
