using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TechieTree.Models
{
    public class TraineeCourseAssignment
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "trainer ID is Required")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Course ID is Required")]
        public string CourseID { get; set; }
    }
}