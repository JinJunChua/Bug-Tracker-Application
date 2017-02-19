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
        ProjectGateway pdb = new ProjectGateway();
        public ProjectController()
        {
            db = new ProjectGateway();
        }

        //Manager - Project/Index
        public ActionResult Index(User user)
        {//ok wait
            IEnumerable<Project> temp = pdb.getProjectData(user);
            
            //wait ah
            return View(pdb.getProjectData(user)); //try
        }

        //Manager - Project/Index > click on Project Details > Click on Cases
        public ActionResult CaseIndex(Project project)
        {
            return View(pdb.getListOfCases(project));
        }

        //public ActionResult Create(User user)
        //{
        //    Project project = new Project();
        //    project.createdBy = (int)user.userID;
        //    return View(project);
        //}

        public ActionResult Create(User user)
        {
            Project p = new Project();
            string tempId = Session["id"].ToString();

            p.createdBy = user.userID;
            return View(p);
        }

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Project p)
        //{
        //    //try comment out this whole section? cuz inherit from CRUDController
        //    //i think you can continue pass the value here
        //    //User user = new User();
        //    //p.createdBy = (int)Session["id"];//try
        //    return View(p);

        //}
        
    }
}
