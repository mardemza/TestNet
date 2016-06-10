namespace TestNet.Web.Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Body = c.String(),
                        CreatedUserId = c.String(nullable: false, maxLength: 128),
                        JobId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedUserId)
                .ForeignKey("dbo.Job", t => t.JobId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        EnabledSeeComment = c.Boolean(nullable: false),
                        EnabledDeleteComment = c.Boolean(nullable: false),
                        EnabledSeeJob = c.Boolean(nullable: false),
                        EnabledEditJob = c.Boolean(nullable: false),
                        EnabledDeleteJob = c.Boolean(nullable: false),
                        ProjectId = c.Long(nullable: false),
                        CreatedUserId = c.String(nullable: false, maxLength: 128),
                        AsignedUserId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AsignedUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedUserId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.AsignedUserId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        CreatedUserId = c.String(nullable: false, maxLength: 128),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedUserId)
                .Index(t => t.CreatedUserId);
            
            CreateTable(
                "dbo.TagProject",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TagId = c.Long(nullable: false),
                        ProjectId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .Index(t => t.TagId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagJob",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TagId = c.Long(nullable: false),
                        JobId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .Index(t => t.TagId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "JobId", "dbo.Job");
            DropForeignKey("dbo.Job", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.TagProject", "TagId", "dbo.Tag");
            DropForeignKey("dbo.TagJob", "TagId", "dbo.Tag");
            DropForeignKey("dbo.TagJob", "JobId", "dbo.Job");
            DropForeignKey("dbo.TagProject", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "CreatedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "CreatedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "AsignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "CreatedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.TagJob", new[] { "JobId" });
            DropIndex("dbo.TagJob", new[] { "TagId" });
            DropIndex("dbo.TagProject", new[] { "ProjectId" });
            DropIndex("dbo.TagProject", new[] { "TagId" });
            DropIndex("dbo.Project", new[] { "CreatedUserId" });
            DropIndex("dbo.Job", new[] { "AsignedUserId" });
            DropIndex("dbo.Job", new[] { "CreatedUserId" });
            DropIndex("dbo.Job", new[] { "ProjectId" });
            DropIndex("dbo.Comment", new[] { "JobId" });
            DropIndex("dbo.Comment", new[] { "CreatedUserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.TagJob");
            DropTable("dbo.Tag");
            DropTable("dbo.TagProject");
            DropTable("dbo.Project");
            DropTable("dbo.Job");
            DropTable("dbo.Comment");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
