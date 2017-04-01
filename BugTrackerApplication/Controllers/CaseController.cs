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
        ProjectGateway pdb = new ProjectGateway();
        CaseGateway cdb = new CaseGateway();
        UserGateway udb = new UserGateway();
        BugGateway bdb = new BugGateway();
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

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Case> emptyList = new List<Case>();
            if (string.IsNullOrEmpty(searchTerm))
            {

                emptyList = cdb.getOtherData().ToList();
            }
            else
            {
                emptyList = cdb.searchCaseData(searchTerm).ToList();
            }

            return View(emptyList);
        }


        //Programmer - Case/Index > Click on Case > Case/Details > Click on Bugs
        public ActionResult ListOfBugs(int cid)
        {
            return View(cdb.getListOfBugs(cid));
        }
        
        //GET after create case, come to this page
        public ActionResult AddBugsToCase(int cid)
        {           
            //get case through passed in cid first
            Case c = new Case();
            c = cdb.getCase(cid);

            //Then, get the project of the case
            Project p = new Project();
            p = pdb.getProject(c.projectID);

            //Then populate the view based on the list of bugs related to the project
            c.availableBugs = bdb.getBugRelatedToProjectName(p.projectName);

            //pass to view
            ViewBag.cid = cid;
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBugsToCase(Case c)
        {
            if (ModelState.IsValid)
            {
                //technically, this is to update the bug to have a case id to it
                foreach (var bug in c.selectedBugs) //value is the id of the bug
                {
                    Bug b = new Bug();
                    b = bdb.getBug(int.Parse(bug));
                    b.caseID = c.caseID;
                    bdb.Update(b);
                }
                return RedirectToAction("Index", "Project");
            }

            return View(c);
        }

        //Search GetData
        public JsonResult GetData(string term)
        {
            List<string> data;
            data = cdb.casedata.Where(x => x.status.StartsWith(term))
                .Select(e => e.status).Distinct().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
