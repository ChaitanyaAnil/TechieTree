using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TechieTree.Models
{
    public class Attendance
    {
		public int ID { get; set; }

		public DateTime ComingTime { get; set; }


		[Display(Name ="Date")]
		public DateTime DateOfDay { get; set; }

		public DateTime? LeaveTime { get; set; }

		public int TraineeID { get; set; }
	}
}