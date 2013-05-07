using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace KittensDb.Core.Services
{
    public class DataService : IDataService
    {
        private readonly ISQLiteConnection _connection;

        public DataService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("one.sql");
            _connection.CreateTable<Kitten>();
        }

        public List<Kitten> KittensMatching(string nameFilter)
        {
            return _connection.Table<Kitten>()
                              .OrderBy(x => x.Price)
                              .Where(x => x.Name.Contains(nameFilter))
                              .ToList();
        }

        public void Insert(Kitten kitten)
        {
            _connection.Insert(kitten);
        }

        public void Update(Kitten kitten)
        {
            _connection.Update(kitten);
        }

        public void Delete(Kitten kitten)
        {
            _connection.Delete(kitten);
        }

        public int Count
        {
            get
            {
                return _connection.Table<Kitten>().Count();
            }
        }
    }
}