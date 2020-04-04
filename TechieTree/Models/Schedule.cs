using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class Schedule
    { 
    
        [Key]
        [Required]
        [Display(Name ="Scheduleid")]
        public int ScheduleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }
        
         public string Content { get; set; }



    }
}