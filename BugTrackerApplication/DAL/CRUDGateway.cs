using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.DAL
{
    public class CRUDGateway<T> : ICRUDGateway<T> where T : class
    {
        internal BugTrackerApplicationContext db = new BugTrackerApplicationContext();
        internal DbSet<T> data = null;

        public CRUDGateway()
        {
            this.data = db.Set<T>();
        }

        public T Delete(int? id)
        {
            T obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public void Insert(T obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            //db.Bug.SqlQuery("select * from dbo.Bug");
            return data.ToList();
        }

        public T SelectById(int? id)
        {
            return data.Find(id);
        }
        
        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges(); 
        }
        


        //======== Fatgirl's codes

        //public void Login(T obj)
        //{
        //    //List<T> newObj = data.ToList<T>();
        //    //newObj.FindAll.

        //}
    }
}