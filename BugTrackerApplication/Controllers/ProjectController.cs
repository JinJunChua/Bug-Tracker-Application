using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApplication.Controllers
{
    public class ProjectController : CRUDController<Project>
    {
        public ProjectController()
        {
            db = new ProjectGateway();
        }

        //Manager View
        public ActionResult Index()
        {
            return View(db.SelectAll());
        }
    }
}
