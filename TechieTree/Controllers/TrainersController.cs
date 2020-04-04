using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TechieTree.Models;

namespace TechieTree.Controllers
{
    public class TrainersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Trainers
        public ActionResult Index()
        {
            return View(db.Trainer.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Trainer account)
        {
            if (ModelState.IsValid)
            {
                using (DataContext db = new DataContext())
                {
                    db.Trainer.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.ID + " " + account.Email + "succsfully registered";
            }
            return View();

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Trainer trainer)
        {
            using (DataContext db = new DataContext())
            {
                var usr = db.Trainer.Single(u => u.Email == trainer.Email && u.Password == trainer.Password);
                if (usr != null)
                {
                    Session["Id"] = usr.ID.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("Loggedin");
                }
                else
                {
                    ModelState.AddModelError("", "error while logging");
                }
            }



            return View();
        }
        public ActionResult Loggedin()
        {

            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Trainers");
        }
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile([Bind(Include = "FileName, FilePath")] FileUploadModel fm1, HttpPostedFileBase fileupload1)
        {
            string filename = string.Empty;
            string filepath = string.Empty;

            filename = fileupload1.FileName;
            string ext = Path.GetExtension(filename);
            if (ext == ".jpg" || ext == ".png")
            {
                DataContext db = new DataContext();
                filepath = Server.MapPath("~//Files//");
                fileupload1.SaveAs(filepath + filename);

                fm1.FileName = filename;
                fm1.FilePath = "~//Files//";

                db.fileuploadmodels.Add(fm1);

                // db.Entry(model).State = EntityState.Modified;

                db.SaveChanges();

                return Content("file is uploaded successfully");

            }
            else
            {
                return Content("You can upload only jpg or png file");
            }
            return View();
        }
        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainer.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,password,Repassword")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainer.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }
        //Get:Trainer/PostSchedule
        public ActionResult PostSchedule()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostSchedule(Schedule scd)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(scd);
                db.SaveChanges();
                return RedirectToAction("ScheduleDetails/id");
            }
            return View(scd);
        }
        public ActionResult ScheduleDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule scd = db.Schedules.Find(id);
            if (scd == null)
            {
                return HttpNotFound();
            }
            return View(scd);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainer.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,password,Repassword")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainer.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainer.Find(id);
            db.Trainer.Remove(trainer);
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
