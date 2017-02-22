using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.Models
{
    public class Case
    {
        [Display(Name = "Case ID")]
        public int caseID { get; set; }
        [Display(Name = "Status")]
        public String status { get; set; }
        [Display(Name = "Project Manager ID")]
        public int pmID { get; set; }
        [Display(Name = "Programmer ID")]
        public int? programmerID { get; set; }
        [Display(Name = "Project ID")]
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