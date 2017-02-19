using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.Models
{
    public class Bug
    {
        public int bugID { get; set; }
        //public int projectID { get; set; }
        public String projectName { get; set; }
        public int customerID { get; set; }
        public String bugDesc { get; set; }
        public String attachments { get; set; }//no options for blob
        public String status { get; set; }
        public String priority { get; set; }
        public String comments { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public DateTime? dueDate { get; set; }
        public int? caseID { get; set; }

        public virtual Case AssignedToCase { get; set; }
        //public virtual Project Assigned

    }
}