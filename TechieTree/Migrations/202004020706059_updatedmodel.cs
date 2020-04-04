namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComingTime = c.DateTime(nullable: false),
                        DateOfDay = c.DateTime(nullable: false),
                        LeaveTime = c.DateTime(),
                        TraineeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Trainees", "salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trainees", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trainees", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Trainees", "UserRoles", c => c.String());
            AlterColumn("dbo.Trainees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Trainees", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Trainees", "RePassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainees", "RePassword", c => c.String());
            AlterColumn("dbo.Trainees", "Password", c => c.String());
            AlterColumn("dbo.Trainees", "Email", c => c.String());
            DropColumn("dbo.Trainees", "UserRoles");
            DropColumn("dbo.Trainees", "ConfirmPassword");
            DropColumn("dbo.Trainees", "BirthDate");
            DropColumn("dbo.Trainees", "salary");
            DropTable("dbo.Attendances");
        }
    }
}
