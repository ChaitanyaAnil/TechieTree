namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingdbmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Eventid = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Eventid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
