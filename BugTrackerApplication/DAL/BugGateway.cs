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
        internal new DbSet<Bug> bugdata = null;

        public BugGateway()
        {
            this.bugdata = db.Set<Bug>();
        }
        public IEnumerable<Bug> getUserBug(User user)
        {
            var allBugsMappedToUser = bugdata.Where(x => x.customerID == user.userID);
            return allBugsMappedToUser.ToList();
        }
    }
}