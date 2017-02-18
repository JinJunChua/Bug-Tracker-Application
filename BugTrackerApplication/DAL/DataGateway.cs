using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.DAL
{
    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal BugTrackerApplicationContext db = new BugTrackerApplicationContext();
        internal DbSet<T> data = null;

        public DataGateway()
        {
            this.data = db.Set<T>();
        }

        public T Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SelectAll()
        {
            throw new NotImplementedException();
        }

        public T SelectById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(int? id, T obj)
        {
            throw new NotImplementedException();
        }
        
    }
}