using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
    }
}
