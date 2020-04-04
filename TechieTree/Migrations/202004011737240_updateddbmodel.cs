namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddbmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderTraineeId", c => c.Int());
            AddColumn("dbo.Messages", "SenderTrainerId", c => c.Int());
            AddColumn("dbo.Messages", "RecieverTraineeId", c => c.Int());
            AddColumn("dbo.Messages", "RecieverTrainerId", c => c.Int());
            DropColumn("dbo.Messages", "SenderStudentId");
            DropColumn("dbo.Messages", "SenderInstructorId");
            DropColumn("dbo.Messages", "RecieverStudentId");
            DropColumn("dbo.Messages", "RecieverInstructorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "RecieverInstructorId", c => c.Int());
            AddColumn("dbo.Messages", "RecieverStudentId", c => c.Int());
            AddColumn("dbo.Messages", "SenderInstructorId", c => c.Int());
            AddColumn("dbo.Messages", "SenderStudentId", c => c.Int());
            DropColumn("dbo.Messages", "RecieverTrainerId");
            DropColumn("dbo.Messages", "RecieverTraineeId");
            DropColumn("dbo.Messages", "SenderTrainerId");
            DropColumn("dbo.Messages", "SenderTraineeId");
        }
    }
}
