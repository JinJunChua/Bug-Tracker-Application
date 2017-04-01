using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BugTrackerApplication.Controllers
{
    public class ProjectController : CRUDController<Project>
    {
        ProjectGateway pdb = new ProjectGateway();
        CaseGateway cdb = new CaseGateway();
        UserGateway udb = new UserGateway();
        BugGateway bdb = new BugGateway();
        UserAssignedProjectGateway uapdb = new UserAssignedProjectGateway();
        private int id = (int)System.Web.HttpContext.Current.Session["userID"];
        private string username = (string)System.Web.HttpContext.Current.Session["UserName"];

        public ProjectController()
        {
            db = new ProjectGateway();
        }
        public ActionResult LogOut()
        {

            //FormsAuthentication.SignOut();
            Session.Clear(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

        //Manager - Project/Index
        public ActionResult Index()
        {
            IEnumerable<Project> temp = pdb.getProjectData(id);
            return View(pdb.getProjectData(id));
        }
        
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Project> emptyList = new List<Project>();
            if (string.IsNullOrEmpty(searchTerm))
            {

                emptyList = pdb.getOtherData().ToList();
            }
            else
            {
                emptyList = pdb.searchCaseData(searchTerm).ToList();
            }

            return View(emptyList);
        }
        
        //Manager - Project/Index > click on Project Details > Click on Cases
        public ActionResult CaseIndex(int pid)
        {
            return View(pdb.getListOfCases(pid));
        }

        //create project page, will then lead to the add programmer page
        public ActionResult CreateProject()
        {
            Project project = new Project();
            project.createdBy = id;
            project.updatedBy = username;
            project.createdDate = DateTime.Now;
            project.endDate = DateTime.Now;
            project.updatedDate = DateTime.Now;
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(Project obj, FormCollection formCollection)
        {
            //TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                pdb.Insert(obj);
                return RedirectToAction("AddProgrammerToProject", new { pid = obj.projectID });
            }

            return View(obj);
        }


        //Add programmer to project
        public ActionResult AddProgrammerToProject(int pid)
        {
            Project p = new Project();
            p = pdb.getProject(pid);
            p.availableProgrammers = udb.GetAllProgrammers();
            p.projectID = pid;
            ViewBag.Message = p.projectID;
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProgrammerToProject(Project obj)
        {
            if (ModelState.IsValid)
            {
                UserAssignedProject uap = new UserAssignedProject();
                foreach (var item in obj.selectedProgrammers)
                {
                    uap.userID = int.Parse(item);
                    uap.projectID = obj.projectID;
                    uapdb.Insert(uap);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Create case and assign the programmer to the case first the bug(s) to the case
        public ActionResult CreateCase(int pid)
        {
            Case c = new Case();
            Project p = new Project();
            c.projectID = pid;
            c.pmID = id; //User that is logged on
            c.AssignedToProject = pdb.getProject(pid);
            //instead of getting all programmer when userAssigned up, get user assigned to project only
            c.listOfProgrammers = udb.GetAllProgrammers();
            ViewData["projectName"] = c.AssignedToProject.projectName;
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCase(Case obj)
        {
            //TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                cdb.Insert(obj);
                //return RedirectToAction("CaseIndex", new { pid = obj.projectID });
                return RedirectToAction("AddBugsToCase", "Case", new { cid = obj.caseID });
            }

            return View(obj);
        }
        
    }
}
