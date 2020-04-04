namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedallmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trainers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trainers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Trainers", "UserRoles", c => c.String());
            AlterColumn("dbo.Trainers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Trainers", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Trainers", "Repassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Repassword", c => c.String());
            AlterColumn("dbo.Trainers", "Password", c => c.String());
            AlterColumn("dbo.Trainers", "Email", c => c.String());
            DropColumn("dbo.Trainers", "UserRoles");
            DropColumn("dbo.Trainers", "ConfirmPassword");
            DropColumn("dbo.Trainers", "BirthDate");
            DropColumn("dbo.Trainers", "salary");
        }
    }
}
