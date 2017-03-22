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

        [Display(Name = "Project Name")]
        public String projectName { get; set; }

        [Display(Name = "Project Title")]
        public String projectDesc { get; set; }

        [Display(Name = "Version")]
        public String projectVersion { get; set; }

        [Display(Name = "Updated By")]
        public String updatedBy { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime createdDate { get; set; }

        [Display(Name = "Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime updatedDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        //public virtual IEnumerable<User> listOfUsers { get; set; }
        public virtual ICollection<Case> listOfCase { get; set; }
        public virtual ICollection<UserAssignedProject> listOfAssignedUsers { get; set; }
        public virtual User Manager { get; set; }

        [Display(Name = "Created By")]
        public int createdBy { get; set; } //by which manager
        

        public Project()
        {
            //listOfUsers = new List<User>();
            listOfCase = new List<Case>();
            listOfAssignedUsers = new List<UserAssignedProject>();
        }
    }
}