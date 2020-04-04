namespace TechieTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databsemodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.String(),
                        CourseTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageBody = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        SenderStudentId = c.Int(),
                        SenderInstructorId = c.Int(),
                        RecieverStudentId = c.Int(),
                        RecieverInstructorId = c.Int(),
                        SenderName = c.String(),
                        RecieverName = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Option = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        CourseID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CourseID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        QuizID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuizID = c.Int(nullable: false),
                        TraineeID = c.Int(nullable: false),
                        TrainerID = c.Int(nullable: false),
                        CourseID = c.String(nullable: false),
                        TotalMarks = c.Int(nullable: false),
                        ObtainedMarks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        password = c.String(),
                        RePassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TraineeCourseAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        password = c.String(),
                        Repassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TrainerCourseAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrainerID = c.Int(nullable: false),
                        CourseID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrainerCourseAssignments");
            DropTable("dbo.Trainers");
            DropTable("dbo.TraineeCourseAssignments");
            DropTable("dbo.Trainees");
            DropTable("dbo.Results");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
            DropTable("dbo.Messages");
            DropTable("dbo.Courses");
        }
    }
}
