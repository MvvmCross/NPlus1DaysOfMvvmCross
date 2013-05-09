using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace CollectABull.Core.Services.DataStore
{
    public class Repository : IRepository
    {
        private readonly ISQLiteConnection _connection;

        public Repository(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("collect.sql");
            _connection.CreateTable<CollectedItem>();
        }

        public List<CollectedItem> All()
        {
            return _connection
                .Table<CollectedItem>()
                .OrderByDescending(x => x.WhenUtc)
                .ToList();
        }

        public CollectedItem Latest
        {
            get
            {
                return _connection
                    .Table<CollectedItem>()
                    .OrderByDescending(x => x.WhenUtc)
                    .FirstOrDefault();
            }
        }

        public void Add(CollectedItem collectedItem)
        {
            _connection.Insert(collectedItem);
        }

        public void Delete(CollectedItem collectedItem)
        {
            _connection.Delete(collectedItem);
        }

        public void Update(CollectedItem collectedItem)
        {
            _connection.Update(collectedItem);
        }
    }
}
