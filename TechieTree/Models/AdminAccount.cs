using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class AdminAccount
    {
        [Key]
        public string AdminId { get; set; }
        [Required(ErrorMessage = "Admin email  is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string AdminEmail { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}