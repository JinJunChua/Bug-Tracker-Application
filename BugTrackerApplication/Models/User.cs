using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApplication.Models
{
    public class User
    {
        public int userID { get; set; }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        [Display(Name = "Password")]
        public string password { get; set; }
        //[Compare("password", ErrorMessage = "Confirm password dose not match.")]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        //public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string FullName { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Please provide valid email id")]
        [Display(Name = "Email")]
        public string EmailID { get; set; }
        [Display(Name = "Role")]
        public String role { get; set; }


       //public int? AssignedProject_projectID { get; set; }
        //public virtual Project AssignedProject { get; set; }

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