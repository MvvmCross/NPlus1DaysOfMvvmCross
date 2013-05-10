using System.Collections.Generic;

namespace CollectABull.Core.Services.DataStore
{
    public interface IRepository
    {
        List<CollectedItem> All();
        CollectedItem Latest { get; }
        void Add(CollectedItem collectedItem);
        void Delete(CollectedItem collectedItem);
        void Update(CollectedItem collectedItem);
        CollectedItem Get(int id);
    }
}