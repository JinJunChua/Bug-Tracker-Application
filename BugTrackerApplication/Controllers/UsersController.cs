using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;

namespace BugTrackerApplication.Controllers
{
    public class UsersController : Controller
    {
        private BugTrackerApplicationContext db = new BugTrackerApplicationContext();
        private UserGateway userGateway = new UserGateway();
        // GET: Users
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            var obj = userGateway.Login(username, password);
            if(obj != null)
            {
                switch (obj.role)
                {
                    case "Admin":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Home");
                        break;

                    case "Customer":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Bug");
                        break;

                    case "Programmer":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Case");
                        break;
                }
                //if (obj.role == "Admin")
                //{
                //    Session["UserID"] = obj.userName.ToString();
                //    Session["Role"] = obj.role.ToString();
                //    return RedirectToAction("Index", "Home");
                //}              

            }
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,userName,password,role,AssignedProject_projectID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userName,password,role,AssignedProject_projectID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
