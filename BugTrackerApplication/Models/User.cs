using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.Models
{
    public class User
    {
        public int userID { get; set; }
        public String userName { get; set; }
        public String password { get; set; }
        public String role { get; set; }

        //public int? AssignedProject_projectID { get; set; }
        public virtual Project AssignedProject { get; set; }

        public virtual ICollection<UserAssignedProject> listOfAssignedProject { get; set; } // for the programmer
        public virtual ICollection<Project> manageProjects { get; set; }
        public virtual ICollection<Case> listOfCase { get; set; }
        public User()
        {
            listOfAssignedProject = new List<UserAssignedProject>();
            manageProjects = new List<Project>();
            listOfCase = new List<Case>();
        }

        public User(string username, string password)
        {
            userName = username;
            this.password = password;
        }
    }
}