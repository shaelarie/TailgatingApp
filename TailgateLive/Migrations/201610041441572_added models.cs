namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TailgateEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        TeamsId = c.Int(nullable: false),
                        EventStatus = c.Boolean(nullable: false),
                        EventRating = c.Int(nullable: false),
                        Comments = c.String(),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodItems", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamsId, cascadeDelete: true)
                .Index(t => t.TeamsId)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Team = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        HostedEventsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HostedEvents", t => t.HostedEventsId, cascadeDelete: true)
                .Index(t => t.HostedEventsId);
            
            CreateTable(
                "dbo.HostedEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TailgateEventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TailgateEvents", t => t.TailgateEventId, cascadeDelete: true)
                .Index(t => t.TailgateEventId);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInformations", "HostedEventsId", "dbo.HostedEvents");
            DropForeignKey("dbo.HostedEvents", "TailgateEventId", "dbo.TailgateEvents");
            DropForeignKey("dbo.TailgateEvents", "TeamsId", "dbo.Teams");
            DropForeignKey("dbo.TailgateEvents", "FoodId", "dbo.FoodItems");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.HostedEvents", new[] { "TailgateEventId" });
            DropIndex("dbo.UserInformations", new[] { "HostedEventsId" });
            DropIndex("dbo.TailgateEvents", new[] { "FoodId" });
            DropIndex("dbo.TailgateEvents", new[] { "TeamsId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.HostedEvents");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Teams");
            DropTable("dbo.TailgateEvents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FoodItems");
        }
    }
}
