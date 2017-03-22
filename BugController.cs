using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApplication.Controllers
{
    public class BugController : CRUDController<Bug>
    {
        BugGateway bdb = new BugGateway();
        int id = (int)System.Web.HttpContext.Current.Session["userID"];
        public BugController()
        {
            db = new BugGateway();            
        }

        //Customer View
        public ActionResult Index()
        {
            return View(bdb.getUserBug(id));
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            Bug bug = new Models.Bug();
            bug.customerID = id;
            return View(bug);
        }
    }
}
