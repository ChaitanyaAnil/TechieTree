using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TechieTree.Models
{
    public class Result
    {
        [Key]
        public int ID { get; set; }

 [Required(ErrorMessage = "Quiz ID is Required !")]
        public int QuizID { get; set; }
        [Required(ErrorMessage = "Student ID is Required !")]
        public int TraineeID { get; set; }
        [Required(ErrorMessage = "Instructor ID is Required !")]
        public int TrainerID { get; set; }
        [Required(ErrorMessage = "Course ID is Required !")]
        public string CourseID { get; set; }
        [Required(ErrorMessage = "Total Marks are Required !")]
        public int TotalMarks { get; set; }
        [Required(ErrorMessage = "Obtained Marks are Required !")]
        public int ObtainedMarks { get; set; }


    }
}