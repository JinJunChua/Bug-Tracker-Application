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
        public BugController()
        {
            db = new BugGateway();            
        }

        //Customer View
        public ActionResult Index(User user)
        {
            return View(bdb.getUserBug(user));
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
