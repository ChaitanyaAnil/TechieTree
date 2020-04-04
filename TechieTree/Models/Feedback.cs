using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TechieTree.Models
{
    public class Feedback
    {
        [Key]
      public int Id { get; set; } 
        public DateTime  FeedbackDate { get; set; }
        public string TraineeName { get; set; }
        public string TopicsUndestand { get; set; }
        public bool IsTrainerGood { get; set; }
        


    }
}