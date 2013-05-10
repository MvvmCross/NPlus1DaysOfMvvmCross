using System.Collections.Generic;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.Services.Collections
{
    public interface ICollectionService
    {
        List<CollectedItem> All();
        CollectedItem Latest { get; }

        CollectedItem Get(int id);
        void Add(CollectedItem item);
        void Delete(CollectedItem item);
    }
}