namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeedbackDate = c.DateTime(nullable: false),
                        TraineeName = c.String(),
                        TopicsUndestand = c.String(),
                        IsTrainerGood = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
