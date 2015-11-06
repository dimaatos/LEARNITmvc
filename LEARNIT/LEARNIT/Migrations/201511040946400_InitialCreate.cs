namespace LEARNIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 200),
                        FieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Field", t => t.FieldId)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        CourseAbout = c.String(maxLength: 1000),
                        CategoryId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Photo", t => t.PhotoId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.CategoryId)
                .Index(t => t.TeacherId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        PhotoName = c.String(),
                        PhotoNameOnServer = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(maxLength: 100),
                        Education = c.String(maxLength: 200),
                        TeacherAbout = c.String(maxLength: 1000),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.Photo", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        SubscriberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .ForeignKey("dbo.Subscriber", t => t.SubscriberID)
                .Index(t => t.CourseID)
                .Index(t => t.SubscriberID);
            
            CreateTable(
                "dbo.Subscriber",
                c => new
                    {
                        SubscriberID = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 100),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriberID)
                .ForeignKey("dbo.Photo", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Field",
                c => new
                    {
                        FieldID = c.Int(nullable: false, identity: true),
                        FieldName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.FieldID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "FieldId", "dbo.Field");
            DropForeignKey("dbo.Subscription", "SubscriberID", "dbo.Subscriber");
            DropForeignKey("dbo.Subscriber", "PhotoId", "dbo.Photo");
            DropForeignKey("dbo.Subscription", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Teacher", "PhotoId", "dbo.Photo");
            DropForeignKey("dbo.Course", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Course", "PhotoId", "dbo.Photo");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropIndex("dbo.Subscriber", new[] { "PhotoId" });
            DropIndex("dbo.Subscription", new[] { "SubscriberID" });
            DropIndex("dbo.Subscription", new[] { "CourseID" });
            DropIndex("dbo.Teacher", new[] { "PhotoId" });
            DropIndex("dbo.Course", new[] { "PhotoId" });
            DropIndex("dbo.Course", new[] { "TeacherId" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "FieldId" });
            DropTable("dbo.Field");
            DropTable("dbo.Subscriber");
            DropTable("dbo.Subscription");
            DropTable("dbo.Teacher");
            DropTable("dbo.Photo");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
        }
    }
}
