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
        //internal DbSet<Case> casedata = null;
        //private IEnumerable<Case> allCaseByName;

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


        // Programmer > Index > Case OR
        // PM > Index > Project > Case > Details > List OF Bugs
        public IEnumerable<Bug> getListOfBugs(int? caseID)
        {
            Case c = casedata.Where(x => x.caseID == caseID).FirstOrDefault();
            return c.listOfBugs.ToList();
        }

        public Case getCase(int caseID)
        {
            Case c = casedata.Where(x => x.caseID == caseID).FirstOrDefault();
            if (c != null)
                return c;
            else
                return null;
        }

        //for prog's search
        //for Cases searches by Programmer
        public IEnumerable<Case> searchCaseData(string searchTerm)
        {
            IEnumerable<Case> allCaseByName = null;

            if (string.IsNullOrEmpty(searchTerm))
            {
                System.Diagnostics.Debug.WriteLine("if Condition ");
                return allCaseByName = casedata.Where(x => x.status == searchTerm).ToList();

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Else Condition ");

                return allCaseByName = casedata.Where(x => x.status.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

        }


    }
}