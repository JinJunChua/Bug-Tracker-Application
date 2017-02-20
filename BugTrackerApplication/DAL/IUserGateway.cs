using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerApplication.DAL
{
    interface IUserGateway<User> where User : class
    {
        //User Login(string username, string password);
        User Login(string username, string password);
        int getUserId(string username);
    }
}
