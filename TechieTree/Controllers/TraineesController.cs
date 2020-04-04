using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TechieTree.Models;

namespace TechieTree.Controllers
{
    public class TraineesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Trainees
        public ActionResult Index()
        {
            return View(db.Trainee.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Trainee account)
        {
            if (ModelState.IsValid)
            {
                using (DataContext db = new DataContext())
                {
                    db.Trainee.Add(account);
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
        public ActionResult Login(Trainee trainee)
        {
            using (DataContext db = new DataContext())
            {
                var usr = db.Trainee.Single(u => u.Email == trainee.Email && u.Password == trainee.Password);
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
            return RedirectToAction("Index", "Trainees");
        }
        public ActionResult DownloadsFile()
        {

            var dir = new System.IO.DirectoryInfo(Server.MapPath("~//Files//"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);


        }
        public FileResult Download(string FileName)
        {
            return new FilePathResult("~//Files//" + FileName,
           System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = FileName
            };
        }
        // GET: Feedbacks/Create
        public ActionResult FeedbackCreate()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeedbackCreate([Bind(Include = "Id,FeedbackDate,TraineeName,TopicsUndestand,IsTrainerGood")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        public ActionResult Details(int id)
        {
            DataContext db = new DataContext();
            FileUploadModel fileUpload = db.fileuploadmodels.Single(x => x.id == id);

            return View(fileUpload);
        }

        public ActionResult PostSchedule()
        {
            using (DataContext db = new DataContext())
            {



            }
            return View();
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
        public ActionResult PostScheduleEdit(int id)
        {
            DataContext db = new DataContext();
            var sch = db.Schedules.SingleOrDefault(X => X.ScheduleId == id);
            return View();
        }
        // GET: Trainees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: Trainees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,salary,BirthDate,Email,Password,ConfirmPassword,UserRoles")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainee.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,salary,BirthDate,Email,Password,ConfirmPassword,UserRoles")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = db.Trainee.Find(id);
            db.Trainee.Remove(trainee);
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
