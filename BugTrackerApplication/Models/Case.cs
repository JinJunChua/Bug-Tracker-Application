using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.Models
{
    public class Case
    {
        public int caseID { get; set; }
        public String status { get; set; }
        public int pmID { get; set; }
        public int? programmerID { get; set; }
        public int projectID { get; set; }

        public virtual ICollection<Bug> listOfBugs { get; set; }

        public virtual User Programmer { get; set; }
        public virtual Project AssignedToProject { get; set; }

        public Case ()
        {
            listOfBugs = new List<Bug>();
        }
    }
}