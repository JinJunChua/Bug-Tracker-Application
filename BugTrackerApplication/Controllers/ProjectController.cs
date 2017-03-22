﻿using BugTrackerApplication.DAL;
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
        CaseGateway cdb = new CaseGateway();
        private int id = (int)System.Web.HttpContext.Current.Session["userID"];
        public ProjectController()
        {
            db = new ProjectGateway();
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

        public ActionResult CreateProject()
        {
            Project project = new Project();
            project.createdBy = id;
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(Project obj)
        {
            //TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                pdb.Insert(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public ActionResult CreateCase(int pid)
        {
            Case c = new Case();
            Project p = new Project(); 
            c.projectID = pid; 
            c.pmID = id; //User that is logged on
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
                return RedirectToAction("CaseIndex", new { pid = obj.projectID });
            }

            return View(obj);
        }


    }
}
