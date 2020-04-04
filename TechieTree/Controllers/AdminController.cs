using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using TechieTree.Models;

namespace TechieTree.Controllers
{
    public class AdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin
        public ActionResult Index()
        {
            using (DataContext db = new DataContext())
            {
                return View(db.AdminAccounts.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminAccount account)
        {
            if (ModelState.IsValid)
            {
                using (DataContext db = new DataContext())
                {
                    db.AdminAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.AdminId + " " + account.AdminEmail + "succsfully registered";
            }
            return View();

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminAccount admin)
        {
            using (DataContext db = new DataContext())
            {
                var adm = db.AdminAccounts.Single(a => a.AdminEmail == admin.AdminEmail && a.Password == admin.Password);
                if (adm != null)
                {
                    Session["AdminId"] = adm.AdminId.ToString();
                    Session["AdminEmail"] = adm.AdminEmail.ToString();
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

            if (Session["AdminId"] != null)
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
            return RedirectToAction("Index", "Admin");
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
        public FileResult Download(string FileName)
        {
            return new FilePathResult("~//Files//" + FileName,
           System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = FileName
            };
        }
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
        public ActionResult PostScheduleEdit(int id)
        {
            DataContext db = new DataContext();
            var sch = db.Schedules.SingleOrDefault(X => X.ScheduleId == id);
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
        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminAccount adminAccount = db.AdminAccounts.Find(id);
            if (adminAccount == null)
            {
                return HttpNotFound();
            }
            return View(adminAccount);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,AdminEmail,Password")] AdminAccount adminAccount)
        {
            if (ModelState.IsValid)
            {
                db.AdminAccounts.Add(adminAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminAccount);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminAccount adminAccount = db.AdminAccounts.Find(id);
            if (adminAccount == null)
            {
                return HttpNotFound();
            }
            return View(adminAccount);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,AdminEmail,Password")] AdminAccount adminAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminAccount);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminAccount adminAccount = db.AdminAccounts.Find(id);
            if (adminAccount == null)
            {
                return HttpNotFound();
            }
            return View(adminAccount);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminAccount adminAccount = db.AdminAccounts.Find(id);
            db.AdminAccounts.Remove(adminAccount);
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
