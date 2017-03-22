﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTrackerApplication.DAL;

using BugTrackerApplication.Models;
using System.Web.Services;

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
        [WebMethod(EnableSession = true)]
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
                        System.Web.HttpContext.Current.Session["userID"] = obj.userID; 
                        return RedirectToAction("Index", "Project");

                    case "Customer":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        System.Web.HttpContext.Current.Session["userID"] = obj.userID;
                        return RedirectToAction("Index", "Bug");

                    case "Programmer":
                        Session["UserID"] = obj.userName.ToString();
                        Session["Role"] = obj.role.ToString();
                        System.Web.HttpContext.Current.Session["userID"] = obj.userID;
                        return RedirectToAction("Index", "Case");
                }          

            }
            return View();
        }

        
    }
}