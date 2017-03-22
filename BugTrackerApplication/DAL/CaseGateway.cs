using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.DAL
{
    public class CaseGateway : CRUDGateway<Case>
    {
        internal DbSet<Case> casedata = null;
        private IEnumerable<Case> allCaseByName;

        public CaseGateway()
        {
            this.casedata = db.Set<Case>();
        }

        // Programmer > Index
        public IEnumerable<Case> getCaseData(int uid)
        {
                var allCaseMappedToUser = casedata.Where(x => x.programmerID == uid);
                return allCaseMappedToUser;
        
        
        }
        //for all other users
        public IEnumerable<Case> getOtherData()
        {
   
            return casedata.ToList();


        }


        //public  Index(string searchTerm)
        //{
        //    BugTrackerApplicationContext db = new BugTrackerApplicationContext();
        //    List<Project> project;
        //    //Retrieve all the of the data
        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        var allCaseMappedToUser = casedata.Where(x => x.programmerID == uid);

        //    }
        //    else
        //    {
        //        project = db.Project.Where(x => x.projectName.StartsWith(searchTerm)).ToList();
        //    }
        //    return allCaseMappedToUser;



        public IEnumerable<Case> searchCaseData(string searchTerm)
        {
            // IEnumerable<Case> allCaseByName = null;
            
            if (string.IsNullOrEmpty(searchTerm))
            {

               return allCaseByName = casedata.Where(x => x.status == searchTerm).ToList() ;

            }
            else
            {
                //return allCaseByName = casedata.Where(x => x.status.StartsWith(searchTerm)).ToList(); 
                return allCaseByName = casedata.Where(x => x.status.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            
        }

        // Programmer > Index > Case OR
        // PM > Index > Project > Case > Details > List OF Bugs
        public IEnumerable<Bug> getListOfBugs(int caseID)
        {
            Case c = casedata.Where(x => x.caseID == caseID).FirstOrDefault();
            return c.listOfBugs.ToList();
        }
    }
}