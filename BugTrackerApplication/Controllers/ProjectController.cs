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

        public ActionResult Create(int id)
        {
            Project project = new Project();
            project.createdBy = id;
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project obj)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Insert(obj);
                TempData["project_obj"] = obj.Manager;
                obj.Manager = (User)TempData["project_obj"];
                return RedirectToAction("Index", "Project", obj.Manager);
            }
            
            return View(obj.Manager);
        }
        //public ActionResult Create()
        //{
        //    Project project = new Project();
        //    project.createdBy = (int)Session["id"];
        //    return View(project);
        //}
    }
}
