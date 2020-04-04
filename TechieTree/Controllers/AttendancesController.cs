using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechieTree.Models;

namespace TechieTree.Controllers
{
    public class AttendancesController : Controller
    {
		private DataContext db = new DataContext();
		[Authorize]
		public ActionResult Index(AttendanceViewModel vm)
		{
			//IEnumerable emp = db.Employee.Where(obj => obj.Email == "ahmed@ahmed.com");
			//var result = db.Employee
			//   .SingleOrDefault(c => c.Email == "ahmed@ahmed.com");
			//ViewBag.Message = result.Email;






			////// look if user coming or not



			Trainee userinfo = JsonConvert.DeserializeObject<Trainee>(User.Identity.Name);
			DateTime todayDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
			bool AttendanceValid = db.Attendances.Any(c => c.DateOfDay == todayDate && c.TraineeID == userinfo.ID);

			if (AttendanceValid == true)
			{
				vm.iscoming = true;
				bool AttendanceAllValid = db.Attendances.Any(c => c.DateOfDay == todayDate && c.TraineeID == userinfo.ID && c.LeaveTime != null);
				if (AttendanceAllValid)
				{
					vm.isLeave = true;
				}

			}
			else
			{
				vm.iscoming = false;
			}




			return View(vm);


		}

		[HttpPost]
		[Authorize]
		public ActionResult Index(Attendance attendance, AttendanceViewModel vm)
		{
			Trainee userinfo = JsonConvert.DeserializeObject<Trainee>(User.Identity.Name);



			DateTime myDateTime = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));

			DateTime todayDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));



			/////////////////////////////implement

			bool AttendanceValid = db.Attendances.Any(c => c.DateOfDay == todayDate && c.TraineeID == userinfo.ID);

			if (AttendanceValid)
			{
				var attendanceRow = db.Attendances.Where(c => c.DateOfDay == todayDate && c.TraineeID == userinfo.ID).Single();
				vm.iscoming = true;
				vm.isLeave = true;
				attendanceRow.LeaveTime = myDateTime;


				db.Entry(attendanceRow).State = EntityState.Modified;
				db.SaveChanges();

				return View(vm);

			}
			else
			{
				int userID = userinfo.ID;
				DateTime now = DateTime.Now;
				vm.isLeave = false;
				Attendance Attendance = new Attendance
				{
					TraineeID = userID,
					ComingTime = myDateTime,
					DateOfDay = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy")),

				};

				db.Attendances.Add(Attendance);
				db.SaveChanges();
				vm.iscoming = true;
				return View(vm);

			}





		}


		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}