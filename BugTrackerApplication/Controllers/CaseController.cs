using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApplication.Controllers
{
    public class CaseController : CRUDController<Case>
    {
        CaseGateway cdb = new CaseGateway();
        private int id = (int)System.Web.HttpContext.Current.Session["userID"];
        public CaseController()
        {
            db = new CaseGateway();
        }

        //Programmer - Case/Index
        public ActionResult Index()
        {
            return View(cdb.getCaseData(id));
        }

        //Programmer - Case/Index > Click on Case > Case/Details > Click on Bugs
        public ActionResult ListOfBugs(int cid)
        {
            return View(cdb.getListOfBugs(cid));
        }
        
    }
}
