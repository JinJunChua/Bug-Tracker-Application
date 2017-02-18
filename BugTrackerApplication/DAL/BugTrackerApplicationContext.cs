using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BugTrackerApplication.Models;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace BugTrackerApplication.DAL
{
    public class BugTrackerApplicationContext : DbContext
    {
        public BugTrackerApplicationContext()
            : base(GetEntityConnectionString())
        {

        }

        public static string GetEntityConnectionString()
        {
            string connectionString = new SqlConnectionStringBuilder
            {
                InitialCatalog = "dev2106db",
                DataSource = "dev2103.database.windows.net",
                IntegratedSecurity = false,
                UserID = "dev2103admin",
                Password = "iloveict2106!",
                MultipleActiveResultSets = true,
                PersistSecurityInfo = true,
            }.ConnectionString;
            return connectionString;

        }

        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<Bug> Bug { get; set; }
        public DbSet<UserAssignedProject> UserAssignedProject { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BugTrackerApplicationContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // —---— Primary Keys —--------- //
            modelBuilder.Entity<User>().HasKey(x => x.userID);
            modelBuilder.Entity<Project>().HasKey(x => x.projectID);
            modelBuilder.Entity<Case>().HasKey(x => x.caseID);
            modelBuilder.Entity<Bug>().HasKey(x => x.bugID);
            modelBuilder.Entity<UserAssignedProject>().HasKey(x => x.userAssignedProjID);

            // ------- Foreign Keys ----------- //
            modelBuilder.Entity<Bug>()// class that has the many relationship
                .HasRequired(a => a.AssignedToCase) // class that has the one relation
                .WithMany(b => b.listOfBugs)
                .HasForeignKey(c => c.caseID).WillCascadeOnDelete(false); // Foreign key id  

            modelBuilder.Entity<Case>() // class that has the many relationship
                .HasRequired(a => a.AssignedToProject) // class that has the one relation
                .WithMany(b => b.listOfCase) // name of the IEnnumerablensrjgndrj
                .HasForeignKey(c => c.projectID).WillCascadeOnDelete(false); // Foreign key id

            modelBuilder.Entity<UserAssignedProject>() // class that has the many relationship
                .HasRequired(a => a.AssignedProject) // class that has the one relation
                .WithMany(b => b.listOfAssignedUsers) // name of the IEnnumerablensrjgndrj
                .HasForeignKey(c => c.userID).WillCascadeOnDelete(false); // Foreign key id

            modelBuilder.Entity<UserAssignedProject>() // class that has the many relationship
                .HasRequired(a => a.UserInvolvedProject) // class that has the one relation
                .WithMany(b => b.listOfAssignedProject) // name of the IEnnumerablensrjgndrj
                .HasForeignKey(c => c.projectID).WillCascadeOnDelete(false); // Foreign key id

            modelBuilder.Entity<Case>() // class that has the many relationship
                .HasRequired(a => a.Programmer) // class that has the one relation
                .WithMany(b => b.listOfCase) // name of the IEnnumerablensrjgndrj
                .HasForeignKey(c => c.programmerID).WillCascadeOnDelete(false); // Foreign key id


            modelBuilder.Entity<Project>() // class that has the many relationship
          .HasRequired(a => a.Manager) // class that has the one relation
          .WithMany(b => b.manageProjects) // name of the IEnnumerablensrjgndrj
          .HasForeignKey(c => c.createdBy).WillCascadeOnDelete(false); // Foreign key id




            var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where !string.IsNullOrEmpty(t.Namespace) &&
                                        t.BaseType != null
                                        && t.BaseType.BaseType != null
                                        && t.BaseType.BaseType.IsGenericType
                                  let genericType = t.BaseType.BaseType.GetGenericTypeDefinition()
                                  where genericType == typeof(EntityTypeConfiguration<>) || genericType == typeof(ComplexTypeConfiguration<>)
                                  select t;

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}