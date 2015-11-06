namespace LEARNIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePhotoDone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subscriber", "PhotoId", "dbo.Photo");
            DropIndex("dbo.Subscriber", new[] { "PhotoId" });
            DropColumn("dbo.Subscriber", "PhotoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscriber", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriber", "PhotoId");
            AddForeignKey("dbo.Subscriber", "PhotoId", "dbo.Photo", "PhotoID");
        }
    }
}
