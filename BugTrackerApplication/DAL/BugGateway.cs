using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;
using System.Data.Entity;
using System.Web.Mvc;

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

        public Bug getBug(int bid)
        {
            var bugs = bugdata.Where(x => x.bugID == bid).FirstOrDefault();
            if (bugs != null)
                return bugs;
            else
                return null;
        }

        public IEnumerable<SelectListItem> getBugRelatedToProjectName(string pName)
        {
            var listOfBugsRelatedToProjectName = bugdata.Where(x => x.projectName.Trim() == pName.Trim()).Select(x => new SelectListItem
            {
                Value = x.bugID.ToString(),
                Text = x.bugDesc.ToString()
            }).ToList();
            return listOfBugsRelatedToProjectName;
        }
    }
}