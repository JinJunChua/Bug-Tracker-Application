using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;

namespace BugTrackerApplication.DAL
{
    public class UserGateway : DataGateway<User>
    {
        public User Login(string username, string password)
        {
            var newObj = db.User.Where(x => x.userName.Equals(username) && x.password == password).FirstOrDefault();
            if (newObj != null)
            {
                string role = newObj.role;
                return newObj;
            }
            return new User();
        }
    }
}