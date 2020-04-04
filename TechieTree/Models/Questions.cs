using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class Questions
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Question is Required !")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Course ID is Required !")]
        public string CourseID { get; set; }
    }
}