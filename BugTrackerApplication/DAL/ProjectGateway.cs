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
        internal new DbSet<Project> projectdata = null;

        public ProjectGateway()
        {
            projectdata = db.Set<Project>();
        }

        //PM > Index
        public IEnumerable<Project> getProjectData(User user)
        {
            var displaysProjectThatUserHas = projectdata.Where(x => x.Manager.userID == user.userID);
            
            return displaysProjectThatUserHas; 
        }

        //PM > Index > Details > Cases (list of cases)
        public IEnumerable<Case> getListOfCases(Project project)
        {
            Project p = projectdata.Where(x => x.projectID == project.projectID).FirstOrDefault();
            return p.listOfCase.ToList();
        }

        
    }
}