﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class QuizQuestions
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Question ID is Required !")]
        public int QuestionID { get; set; }
        [Required(ErrorMessage = "Quiz ID is Required !")]
        public int QuizID { get; set; }
    }
}