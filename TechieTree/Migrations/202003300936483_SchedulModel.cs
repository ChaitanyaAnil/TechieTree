namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchedulModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DatePosted = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedules");
        }
    }
}
