using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;
using System.Data.Entity;

namespace BugTrackerApplication.DAL
{
    public class BugGateway : CRUDGateway<Bug>
    {
        internal DbSet<Bug> bugdata = null;

        public BugGateway()
        {
            this.bugdata = db.Set<Bug>();
        }
        public IEnumerable<Bug> getUserBug(int id)
        {
            var allBugsMappedToUser = bugdata.Where(x => x.customerID == id);
            return allBugsMappedToUser.ToList();
        }

           

    }
}