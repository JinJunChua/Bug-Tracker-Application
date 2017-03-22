using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;
using System.Data.Entity;

namespace BugTrackerApplication.DAL
{
    public class ProjectGateway : CRUDGateway<Project>
    {
        internal DbSet<Project> projectdata = null;

        public ProjectGateway()
        {
            projectdata = db.Set<Project>();
        }

        //PM > Index
        public IEnumerable<Project> getProjectData(int id)
        {
            var displaysProjectThatUserHas = projectdata.Where(x => x.Manager.userID == id);            
            return displaysProjectThatUserHas; 
        }

        //PM > Index > Details > Cases (list of cases)
        public IEnumerable<Case> getListOfCases(int pid)
        {
            Project p = projectdata.Where(x => x.projectID == pid).FirstOrDefault();
            if (p != null)
                return p.listOfCase.ToList();
            else
                return null;
        }

        
    }
}