namespace ZenithDataLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Activity_ActivityId", c => c.Int());
            CreateIndex("dbo.Events", "Activity_ActivityId");
            AddForeignKey("dbo.Events", "Activity_ActivityId", "dbo.Activities", "ActivityId");
            DropColumn("dbo.Events", "Activity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Activity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "Activity_ActivityId", "dbo.Activities");
            DropIndex("dbo.Events", new[] { "Activity_ActivityId" });
            DropColumn("dbo.Events", "Activity_ActivityId");
        }
    }
}
