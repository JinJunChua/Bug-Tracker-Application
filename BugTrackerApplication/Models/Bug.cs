using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.Models
{
    public class Bug
    {
        public int bugID { get; set; }
        //public int projectID { get; set; }
        [Display(Name = "Project Name")]
        public String projectName { get; set; }
        [Display(Name = "Customer ID")]
        public int customerID { get; set; }
        [Display(Name = "Bug Description")]
        public String bugDesc { get; set; }
        [Display(Name = "Attachments")]
        public String attachments { get; set; }//no options for blob
        [Display(Name = "Status")]
        public String status { get; set; }
        [Display(Name = "Priority")]
        public String priority { get; set; }
        [Display(Name = "Comments")]
        public String comments { get; set; }
        [Display(Name = "Created Date")]
        public DateTime? createdDate { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime? updatedDate { get; set; }
        [Display(Name = "Due Date")]
        public DateTime? dueDate { get; set; }
        public int? caseID { get; set; }

        [Display (Name = "Resolved")]
        //for programmer
        public bool checkBoxStatus { get; set; }

        public virtual Case AssignedToCase { get; set; }
        //public virtual Project Assigned

    }
}