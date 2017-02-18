namespace BugTrackerApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bug",
                c => new
                    {
                        bugID = c.Int(nullable: false, identity: true),
                        projectName = c.String(),
                        customerID = c.Int(nullable: false),
                        bugDesc = c.String(),
                        attachments = c.String(),
                        status = c.String(),
                        priority = c.String(),
                        comments = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        updatedDate = c.DateTime(nullable: false),
                        dueDate = c.DateTime(nullable: false),
                        caseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bugID)
                .ForeignKey("dbo.Case", t => t.caseID)
                .Index(t => t.caseID);
            
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        caseID = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        pmID = c.Int(nullable: false),
                        programmerID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.caseID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.User", t => t.programmerID)
                .Index(t => t.programmerID)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        projectID = c.Int(nullable: false, identity: true),
                        projectName = c.String(),
                        projectDesc = c.String(),
                        projectVersion = c.String(),
                        updatedBy = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        updatedDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        createdBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.projectID)
                .ForeignKey("dbo.User", t => t.createdBy)
                .Index(t => t.createdBy);
            
            CreateTable(
                "dbo.UserAssignedProject",
                c => new
                    {
                        userAssignedProjID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userAssignedProjID)
                .ForeignKey("dbo.Project", t => t.userID)
                .ForeignKey("dbo.User", t => t.projectID)
                .Index(t => t.userID)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        password = c.String(),
                        role = c.String(),
                        AssignedProject_projectID = c.Int(),
                    })
                .PrimaryKey(t => t.userID)
                .ForeignKey("dbo.Project", t => t.AssignedProject_projectID)
                .Index(t => t.AssignedProject_projectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bug", "caseID", "dbo.Case");
            DropForeignKey("dbo.Case", "programmerID", "dbo.User");
            DropForeignKey("dbo.Case", "projectID", "dbo.Project");
            DropForeignKey("dbo.Project", "createdBy", "dbo.User");
            DropForeignKey("dbo.UserAssignedProject", "projectID", "dbo.User");
            DropForeignKey("dbo.User", "AssignedProject_projectID", "dbo.Project");
            DropForeignKey("dbo.UserAssignedProject", "userID", "dbo.Project");
            DropIndex("dbo.User", new[] { "AssignedProject_projectID" });
            DropIndex("dbo.UserAssignedProject", new[] { "projectID" });
            DropIndex("dbo.UserAssignedProject", new[] { "userID" });
            DropIndex("dbo.Project", new[] { "createdBy" });
            DropIndex("dbo.Case", new[] { "projectID" });
            DropIndex("dbo.Case", new[] { "programmerID" });
            DropIndex("dbo.Bug", new[] { "caseID" });
            DropTable("dbo.User");
            DropTable("dbo.UserAssignedProject");
            DropTable("dbo.Project");
            DropTable("dbo.Case");
            DropTable("dbo.Bug");
        }
    }
}
