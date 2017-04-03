using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApplication.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Security;

namespace BugTrackerApplication.DAL
{
    public class UserGateway : IUserGateway<User>
    {
        internal BugTrackerApplicationContext db = new BugTrackerApplicationContext();
        internal DbSet<User> data = null;
        
        public UserGateway()
        {
            this.data = db.Set<User>();
        }

        public User Login(string username, string password)
        {
            var newObj = db.User.Where(x => x.userName.Equals(username) && x.password == password).FirstOrDefault();
            if (newObj != null)
            {
                string role = newObj.role;
                int id = newObj.userID;
                return newObj;
            }
            return new User();
        }


        public int getUserId(string username)
        {
            var findUserId = db.User.Where(x => x.userName.Equals(username)).FirstOrDefault();
            if (findUserId != null)
                return findUserId.userID;
            else
                return 0;
        }

        public string getUsername(int id)
        {
            var findUsername = db.User.Where(x => x.userID == id).FirstOrDefault();
            if (findUsername != null)
                return findUsername.userName;
            else
                return null;
        }

        public User getUser(int id)
        {
            var findUser = db.User.Where(x => x.userID == id).FirstOrDefault();
            if (findUser != null)
                return findUser;
            else
                return null;
        }

        public IEnumerable<SelectListItem> GetAllProgrammers()
        {
            var listOfProgrammers = db.User.Where(x => x.role == "Programmer").Select(x => new SelectListItem
            {
                Value = x.userID.ToString(),
                Text = x.userName.ToString(),

            }).ToList();

            //return new SelectList(listOfProgrammers, "Value", "Text");
            return listOfProgrammers;
        }


        //public void Insert(T obj)
        //{
        //    data.Add(obj);
        //    db.SaveChanges();
        //}
        
        public void Register_(User U)
        {
                data.Add(U);
                db.SaveChanges();
           
            }


        }



    }
