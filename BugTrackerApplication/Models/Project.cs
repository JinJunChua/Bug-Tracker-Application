using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Web;

namespace BugTrackerApplication.Models
{
    public class Project
    {
        public int projectID { get; set; }
        public String projectName { get; set; }
        public String projectDesc { get; set; }
        public String projectVersion { get; set; }
        public String updatedBy { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime createdDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime updatedDate { get; set; }
        public DateTime endDate { get; set; }
        //public virtual IEnumerable<User> listOfUsers { get; set; }
        public virtual ICollection<Case> listOfCase { get; set; }
        public virtual ICollection<UserAssignedProject> listOfAssignedUsers { get; set; }
        public virtual User Manager { get; set; }
        public int createdBy { get; set; } //by which manager

        public Project()
        {
            //listOfUsers = new List<User>();
            listOfCase = new List<Case>();
            listOfAssignedUsers = new List<UserAssignedProject>();
        }
    }
}