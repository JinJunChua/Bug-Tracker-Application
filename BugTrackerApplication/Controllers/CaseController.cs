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
        public CaseController()
        {
            db = new CaseGateway();
        }

        //Programmer - Case/Index
        public ActionResult Index(User user)
        {
            return View(cdb.getCaseData(user));
        }

        //Programmer - Case/Index > Click on Case > Case/Details > Click on Bugs
        public ActionResult ListOfBugs(Case cases)
        {
            return View(cdb.getListOfBugs(cases));
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
