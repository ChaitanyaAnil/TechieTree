﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class Trainee
    {
        [Key]
		public int ID { get; set; }
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Salary")]
		public decimal salary { get; set; }

		[Display(Name = "Birth Date")]
		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }



		[Display(Name = "Email")]

		[Required(ErrorMessage = "The email address is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }



		[Display(Name = "UserRoles")]
		public string UserRoles { get; set; }
	}
}