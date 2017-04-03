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
        //DbSet<Bug> bugdata = null;
        //private IEnumerable<Bug> allCaseByName;

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

        //for search
        //for all other users
        public IEnumerable<Bug> getOtherData()
        {
            return bugdata.ToList();
        }


        //public IEnumerable<Bug> searchbugData(string searchTerm)
        //{
        //    // IEnumerable<Case> allCaseByName = null;

        //    if (string.IsNullOrEmpty(searchTerm))
        //    {

        //        return allCaseByName = bugdata.Where(x => x.projectName == searchTerm).ToList();

        //    }
        //    else
        //    {
        //        //return allCaseByName = casedata.Where(x => x.status.StartsWith(searchTerm)).ToList(); 
        //        return allCaseByName = bugdata.Where(x => x.projectName.ToLower().Contains(searchTerm.ToLower())).ToList();
        //    }

        //}
    }
}