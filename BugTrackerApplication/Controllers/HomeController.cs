using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BugTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        private BugTrackerApplicationContext db;

        public HomeController()
        {
            db = new BugTrackerApplicationContext();
            var allBugs = db.Bug;
            var allCase = db.Case;
            var allProject = db.Project;
            var allUsers = db.User;
            //TODO: ADD STUFF

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                /* Dont remove this, its necessary at later part.
                string role = Session["Role"].ToString();
                switch (role)
                {
                    case "Admin":
                        return RedirectToAction("Index", "Home");
                    case "Customer":
                        return RedirectToAction("Index", "Home");
                    case "Programmer":
                        return RedirectToAction("Index", "Home");
                 }
                 */
                return View();
            } 
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


//db.User.Add(new User()
//{
//    password = "fatgirl",
//    role = "Admin",
//    userName = "jinjun1995",
//});
//db.SaveChanges();

//db.Project.Add(new Project()
//{
//    createdBy = 1,
//    createdDate = DateTime.Now,
//    endDate = DateTime.Now,
//    projectDesc = "Descr",
//    projectID = 1,
//    projectName = "new",
//    projectVersion = "s",
//    updatedBy = "a",
//    updatedDate = DateTime.Now
//});
//db.SaveChanges();

//db.Case.Add(new Case()
//{
//    caseID = 1,
//    pmID = 1,
//    programmerID = 1,
//    projectID = 1,
//    status = "Ongoing"
//});
//db.SaveChanges();

//db.Bug.Add(new Bug()
//{
//    attachments = string.Empty,
//    bugDesc = "a bug desc",
//    bugID = 1,
//    comments = "aadsf",
//    //createdDate = new DateTime(),
//    customerID = 1,
//    //dueDate = new DateTime(),
//    priority = "High",
//    projectName = "A prject",
//    status = "Status",
//    caseID = 2
//    //updatedDate = new DateTime()
//});

//db.SaveChanges();