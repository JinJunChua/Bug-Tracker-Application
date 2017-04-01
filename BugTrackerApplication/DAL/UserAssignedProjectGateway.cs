using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;
using System.Data.Entity;

namespace BugTrackerApplication.DAL
{
    public class UserAssignedProjectGateway : CRUDGateway<UserAssignedProject>
    {
        internal DbSet<UserAssignedProject> userAssignedData = null;

        public UserAssignedProjectGateway()
        {
            userAssignedData = db.Set<UserAssignedProject>();
        }
    }
}