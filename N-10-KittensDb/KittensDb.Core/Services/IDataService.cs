using System.Collections.Generic;

namespace KittensDb.Core.Services
{
    public interface IDataService
    {
        List<Kitten> KittensMatching(string nameFilter);
        void Insert(Kitten kitten);
        void Update(Kitten kitten);
        void Delete(Kitten kitten);
        int Count { get; }
    }
}