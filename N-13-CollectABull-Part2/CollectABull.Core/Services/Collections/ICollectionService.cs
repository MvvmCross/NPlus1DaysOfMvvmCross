using System.Collections.Generic;
using CollectABull.Core.Services.DataStore;

namespace CollectABull.Core.Services.Collections
{
    public interface ICollectionService
    {
        List<CollectedItem> All();
        CollectedItem Latest { get; }

        void Add(CollectedItem item);

        // add more methods later
    }
}