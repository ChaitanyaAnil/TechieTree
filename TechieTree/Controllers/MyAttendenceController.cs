using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechieTree.Models;

namespace TechieTree.Controllers
{
    public class MyAttendenceController : Controller
    {
        private DataContext db = new DataContext();

        // GET: MyAttendance


        

        public ActionResult Index()
        {

            Trainee userinfo = JsonConvert.DeserializeObject<Trainee>(User.Identity.Name);
            int userID = Int32.Parse(userinfo.ID.ToString());

            List<Attendance> attendanceList = db.Attendances.ToList().Where(x => x.TraineeID == userID).ToList();



            return View(attendanceList);
        }

        public ActionResult All(int? page)
        {



            List<Trainee> Employees = db.Trainee.ToList();

            List<Attendance> attendanceList = db.Attendances.ToList();


            List<SelectListItem> listDD = new List<SelectListItem>();

            foreach (var e in Employees)
            {
                listDD.Add(new SelectListItem
                {
                    Value = e.ID.ToString(),
                    Text = e.FirstName + e.LastName

                });

            }



            TempData["Employees"] = listDD;
            TempData["EmployeesNames"] = Employees;








            return View(attendanceList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult All(int? Employee, int? page, string start, string end)
        {


            List<Attendance> attendanceList;




            if (Employee != null)
            {

                if (start != "" && end != "")
                {


                    DateTime dtstart = Convert.ToDateTime(start);
                    DateTime dtend = Convert.ToDateTime(end);

                    attendanceList = db.Attendances.ToList().Where(x => x.TraineeID == Employee && x.DateOfDay >= dtstart && dtend >= x.DateOfDay).ToList();

                }
                else
                {

                    attendanceList = db.Attendances.ToList().Where(x => x.TraineeID == Employee).ToList();
                }

                //int userID = Int32.Parse(Employee);

            }
            else if (start != "" && end != "" && Employee == null)
            {

                DateTime dtstart = Convert.ToDateTime(start);
                DateTime dtend = Convert.ToDateTime(end);
                attendanceList = db.Attendances.ToList().Where(x => x.DateOfDay >= dtstart && dtend >= x.DateOfDay).ToList();

            }
            else
            {
                attendanceList = db.Attendances.ToList();
            }

            List<Trainee> Employees = db.Trainee.ToList();

            List<SelectListItem> listDD = new List<SelectListItem>();
            foreach (var e in Employees)
            {
                listDD.Add(new SelectListItem
                {
                    Value = e.ID.ToString(),
                    Text = e.FirstName + " " + e.LastName

                });

            }
            TempData["Employees"] = listDD;
            TempData["EmployeesNames"] = Employees;
            TempData["Start"] = start;
            TempData["End"] = end;




            return View(attendanceList);
        }

        // GET: MyAttendence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

       
        // GET: MyAttendence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: MyAttendence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ComingTime,DateOfDay,LeaveTime,TraineeID")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendance);
        }

        // GET: MyAttendence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: MyAttendence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
