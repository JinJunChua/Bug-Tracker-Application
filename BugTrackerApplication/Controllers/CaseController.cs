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

        public JsonResult GetData(string term)
        {
            List<string> data;
            data = cdb.casedata.Where(x => x.status.StartsWith(term))
                .Select(e => e.status).Distinct().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Programmer - Case/Index > Click on Case > Case/Details > Click on Bugs
        public ActionResult ListOfBugs(int cid)
        {
            return View(cdb.getListOfBugs(cid));
        }

     
        
    }
}
