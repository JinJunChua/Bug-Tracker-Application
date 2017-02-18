using BugTrackerApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApplication.Controllers
{
    public class CRUDController<T> : Controller where T : class
    {
        protected CRUDGateway<T> db;

        // GET: CRUD
        //public ActionResult Index()
        //{
        //    return View(db.SelectAll());
        //}

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            return View(db.SelectById(id));
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(T obj)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Insert(obj);
                return RedirectToAction("Index");
            }

            //return View(booking);            
            return View(obj);
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.SelectById(id));
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(T obj)
        {
            //try
            //{
            //    // TODO: Add update logic here                
            //    db.Update(obj);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View(obj);
            //}
            db.Update(obj);
            return RedirectToAction("Index");
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.SelectById(id));
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
