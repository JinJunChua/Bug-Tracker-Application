using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApplication.Controllers
{
    public class BugController : CRUDController<Bug>
    {
        BugGateway bdb = new BugGateway();
        //for cases searches by customer

        int id = (int)System.Web.HttpContext.Current.Session["userID"];
        public BugController()
        {
            db = new BugGateway();            
        }

        //Customer View
        public ActionResult Index()
        {
            return View(bdb.getUserBug(id));
        }


        //Method to pass search value to CRUD
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List< Bug> emptyList = new List<Bug>();
            if (string.IsNullOrEmpty(searchTerm))
            {
                //When search is empty returns all bugs 
                emptyList = bdb.getUserBug(id).ToList();
            }
            else
            {
                //When search returns only the specified bug
                emptyList = bdb.searchbugData(searchTerm).ToList();
            }

            return View(emptyList);
        }

        //Search GetData
        public JsonResult GetData(string term)
        {
            List<string> data;
            data = bdb.bugdata.Where(x => x.projectName.StartsWith(term))
                .Select(e => e.projectName).Distinct().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateBug()
        {
            Bug bug = new Bug();
            bug.customerID = id;
            return View(bug);
            //return View();
        }

        //[ActionName("Create_")]
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBug([Bind(Include = "projectName,customerID,bugDesc,status,priority,comments,createdDate,updatedDate,dueDate")] Bug bug, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) //here is false. oohhh
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".JPG", ".PNG", ".JPEG" };
                string msg = "";
                string relativePath = "";
                System.Diagnostics.Debug.WriteLine("File length " + Request.Files.Count.ToString());
                if (file != null && file.ContentLength > 0)
                {
                 
                    var extension = Path.GetExtension(file.FileName);
                    System.Diagnostics.Debug.WriteLine("filename: " + file.FileName);
                    String attachName = file.FileName;
                    try
                    {
                        if (!allowedExtensions.Contains(extension))
                        {
                            msg = "Invalid file. Please choose either .jpg, .jpeg or .png images";
                        }
                        else
                        {
                            
                            relativePath = "~/Images/Bug/" + attachName;                         
                            string path = Path.Combine(Server.MapPath("~/Images/Bug"),
                                                      attachName);
                            System.Diagnostics.Debug.WriteLine("Normal Path: " + path);
                            System.Diagnostics.Debug.WriteLine("relPath: " + relativePath);
                            file.SaveAs(path);

                            msg = "File uploaded successfully";
                        }
                    }
                    catch (Exception ex)
                    {
                        msg = "File upload failed";
                    }
                }
                else
                {
                    msg = "Please choose a file";
                }
                bug.attachments = relativePath;
                System.Diagnostics.Debug.WriteLine("RelPath2 is: " + relativePath);           
                db.db.Bug.Add(bug);
                db.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bug);
        }


    }
}
