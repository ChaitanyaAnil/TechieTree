using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace TechieTree.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("conn") { }
        public DbSet<FileUploadModel> fileuploadmodels { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<TrainerCourseAssignment> TrainerrCourseAssignment { get; set; }
        public DbSet<TraineeCourseAssignment> TraineeCourseAssignment { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<QuizQuestions> QuizQuestions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AdminAccount> AdminAccounts { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
