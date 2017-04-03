using BugTrackerApplication.Models;
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

        //for Project searches by PM
        internal DbSet<Project> projectdata = null;
        private IEnumerable<Project> allProjsByName;

        //for cases searches by Programmer
        internal DbSet<Case> casedata = null;
        private IEnumerable<Case> allCasesByName;

        //for cases searches by customer
        internal DbSet<Bug> bugdata = null;
        //for cases searches by customer
        private IEnumerable<Bug> allBugsByName;


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

        //For Customer search
        public IEnumerable<Bug> searchbugData(string searchTerm)
        {
            return allBugsByName = bugdata.Where(x => x.projectName.ToLower().Contains(searchTerm.ToLower())).ToList();
        }




        //for Cases searches by Programmer
        public IEnumerable<Case> searchCaseData(string searchTerm1)
        {
            return allCasesByName = casedata.Where(x => x.status.ToLower().Contains(searchTerm1.ToLower())).ToList();
        }

        public IEnumerable<Project> searchProjectData(string searchTerm)
        {
          
           return allProjsByName = projectdata.Where(x => x.projectName.ToLower().Contains(searchTerm.ToLower())).ToList();

          

        }

    }







    //======== Fatgirl's codes

    //public void Login(T obj)
    //{
    //    //List<T> newObj = data.ToList<T>();
    //    //newObj.FindAll.

    //}
}

