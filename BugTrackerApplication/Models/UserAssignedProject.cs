using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApplication.Models
{
    public class UserAssignedProject
    {
        public int userID { get; set; }
        public int projectID { get; set; }
        public int userAssignedProjID { get; set; }

        public virtual Project AssignedProject { get; set; }
        public virtual User UserInvolvedProject { get; set; }
        

    }
}