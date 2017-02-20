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
        internal new DbSet<Case> casedata = null;

        public CaseGateway()
        {
            this.casedata = db.Set<Case>();
        }

        // Programmer > Index
        public IEnumerable<Case> getCaseData(User user)
        {
            if(user.role == "Programmer")
            {
                var allCaseMappedToUser = casedata.Where(x => x.programmerID == user.userID);
                return allCaseMappedToUser;
            }
            else //admin
            {
                var allCaseMappedToUser = casedata.Where(x => x.pmID == user.userID);
                return allCaseMappedToUser;
            }
                
        }

        // Programmer > Index > Case OR
        // PM > Index > Project > Case
        public IEnumerable<Bug> getListOfBugs(int caseID)
        {
            Case c = casedata.Where(x => x.caseID == caseID).FirstOrDefault();
            return c.listOfBugs.ToList();
        }
    }
}