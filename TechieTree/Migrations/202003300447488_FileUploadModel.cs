namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileUploadModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.filesupload",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.filesupload");
        }
    }
}
