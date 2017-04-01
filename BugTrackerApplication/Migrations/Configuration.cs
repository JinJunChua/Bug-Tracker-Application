namespace BugTrackerApplication.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackerApplication.DAL.BugTrackerApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BugTrackerApplication.Models.ApplicationDbContext";
        }

        protected override void Seed(BugTrackerApplication.DAL.BugTrackerApplicationContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);
            
            db.User.Add(new User()
            {
                password = "password",
                role = "Customer",
                userName = "Helppls",
            });

            //db.Bug.Add(new Bug()
            //{
            //    attachments = string.Empty,
            //    bugDesc = "a bug desc",
            //    bugID = 1,
            //    comments = "aadsf",
            //    createdDate = new DateTime(),
            //    customerID = 1,
            //    dueDate = new DateTime(),
            //    priority = "High",
            //    projectName = "A prject",
            //    status = "Status",
            //    updatedDate = new DateTime()
            //});
        }
    }
}
