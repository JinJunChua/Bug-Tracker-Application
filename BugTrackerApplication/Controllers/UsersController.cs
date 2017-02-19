using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;

namespace BugTrackerApplication.Controllers
{
    public class UsersController : Controller
    {
        private BugTrackerApplicationContext db = new BugTrackerApplicationContext();
        private UserGateway userGateway = new UserGateway();
        // GET: Users
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            var obj = userGateway.Login(username, password);
            User user = db.User.Where(x => x.userName == username).FirstOrDefault();

            if(obj != null)
            {
                switch (obj.role)
                {
                    case "Admin":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        Session["id"] = obj.userID.ToString(); 
                        
                        return RedirectToAction("Index", "Project", user);
                        //break;

                    case "Customer":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Bug", user);
                        //break;

                    case "Programmer":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Case", user);
                        //break;
                }
                //if (obj.role == "Admin")
                //{
                //    Session["UserID"] = obj.userName.ToString();
                //    Session["Role"] = obj.role.ToString();
                //    return RedirectToAction("Index", "Home");
                //}              

            }
            return View();
        }

        
    }
}
