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
using System.Web.Services;

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
        [WebMethod(EnableSession = true)]
        public ActionResult Login(String username, String password)
        {
            var obj = userGateway.Login(username, password);

            if(obj != null)
            {
                System.Web.HttpContext.Current.Session["role"] = obj.role;
                switch (obj.role)
                {
                    case "Admin":
                        System.Web.HttpContext.Current.Session["userID"] = obj.userID;
                        System.Web.HttpContext.Current.Session["userName"] = obj.userName;
                        return RedirectToAction("Index", "Project");

                    case "Customer":
                        System.Web.HttpContext.Current.Session["userID"] = obj.userID;
                        System.Web.HttpContext.Current.Session["userName"] = obj.userName;
                        return RedirectToAction("Index", "Bug");

                    case "Programmer":
                        System.Web.HttpContext.Current.Session["userID"] = obj.userID;
                        System.Web.HttpContext.Current.Session["userName"] = obj.userName;
                        return RedirectToAction("Index", "Case");
                }          

            }
            return View();
        }        
    }
}
