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
        private IEnumerable<Project> allCaseByName;



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

        //for all other users
        public IEnumerable<Project> getOtherData()
        {

            return projectdata.ToList();


        }

        public IEnumerable<Project> searchCaseData(string searchTerm)
        {
          

            if (string.IsNullOrEmpty(searchTerm))
            {

                return allCaseByName = projectdata.Where(x => x.projectDesc == searchTerm).ToList();

            }
            else
            {
                //return allCaseByName = casedata.Where(x => x.status.StartsWith(searchTerm)).ToList(); 
                return allCaseByName = projectdata.Where(x => x.projectDesc.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

        }


    }
}