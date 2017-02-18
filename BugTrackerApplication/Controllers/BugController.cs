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
        public BugController()
        {
            db = new BugGateway();
        }

        //Customer View
        public ActionResult Index()
        {
            return View(db.SelectAll());
        }
    }
}
