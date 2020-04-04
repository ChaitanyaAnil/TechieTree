namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegartionMode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminAccounts",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                        AdminEmail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminAccounts");
        }
    }
}
