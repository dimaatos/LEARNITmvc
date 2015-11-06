namespace LEARNIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriber", "CourseRequest", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriber", "CourseRequest");
        }
    }
}
