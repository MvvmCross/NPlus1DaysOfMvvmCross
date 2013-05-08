using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.Services.Collections
{
    public class CollectionService
        : ICollectionService
    {
        private readonly IRepository _repository;

        public CollectionService(IRepository repository)
        {
            _repository = repository;
        }

        public List<CollectedItem> All()
        {
            return _repository.All();
        }

        public void Add(CollectedItem item)
        {
            _repository.Add(item);
            // TODO - send message telling people about the new item
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
