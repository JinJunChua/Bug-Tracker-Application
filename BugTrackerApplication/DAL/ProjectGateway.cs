using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace BugTrackerApplication.DAL
{
    public class ProjectGateway : CRUDGateway<Project>
    {
        //internal DbSet<Project> projectdata = null;
        internal DbSet<UserAssignedProject> userAssignedProject = null;
        //private IEnumerable<Project> allCaseByName;
       // public DbSet<Project> Context;

        public ProjectGateway()
        {
            projectdata = db.Set<Project>();
           // Context = db.Set<Project>();
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
        
        public Project getProject(int pid)
        {
            Project p = projectdata.Where(x => x.projectID == pid).FirstOrDefault();
            if (p != null)
                return p;
            else
                return null;
        }

        public String getProjectName(int pid)
        {
            Project p = projectdata.Where(x => x.projectID == pid).FirstOrDefault();
            if (p != null)
                return p.projectName;
            else
                return null;
        }


        //for all other users
        public IEnumerable<Project> getOtherData()
        {

            return projectdata.ToList();
        }

        //public IEnumerable<Project> searchCaseData(string searchTerm)
        //{


        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        System.Diagnostics.Debug.WriteLine("if Condition ");

        //        return allCaseByName = projectdata.Where(x => x.projectDesc == searchTerm).ToList();   
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine("Else Condition ");
        //        //return allCaseByName = casedata.Where(x => x.status.StartsWith(searchTerm)).ToList(); 
        //        //return allCaseByName = projectdata.Where(x => x.projectDesc.ToLower().Contains(searchTerm.ToLower())).ToList();
        //        return allCaseByName = projectdata.Where(x => x.projectName.ToLower().Contains(searchTerm.ToLower())).ToList();
                 
        //    }

        //}
    }
}