﻿using BugTrackerApplication.DAL;
using BugTrackerApplication.Models;
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

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            return View(db.SelectById(id));
        }


        // POST: CRUD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T obj)
        {
            //TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Insert(obj);
                return RedirectToAction("Index");
            }
            
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
            db.Update(obj);
            return RedirectToAction("Index");
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.SelectById(id));
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

        public ActionResult LogOut()
        {
            //FormsAuthentication.SignOut();
            Session.Clear(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

    }
}
