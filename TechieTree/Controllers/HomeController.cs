using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechieTree.Models;

namespace TechieTree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Landing()
        {
            return View();
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
            public ActionResult PostScheduleEdit(int id)
            {
            DataContext db = new DataContext();
            var sch = db.Schedules.SingleOrDefault(X => X.ScheduleId ==id) ;
                return View();
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