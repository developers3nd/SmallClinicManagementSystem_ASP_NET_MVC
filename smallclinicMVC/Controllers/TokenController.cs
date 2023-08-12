using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smallclinicMVC.Models;

namespace smallclinicMVC.Controllers
{
    public class TokenController : Controller
    {
        dbClinicSystemEntities db = new dbClinicSystemEntities();
        public ActionResult Index()
        {
            var query = db.token_details.ToList();

            return View(query);
        }

        public ActionResult Create()
        {
            List<Doctor> doctorList = db.Doctors.ToList();
            ViewBag.doctorlst = new SelectList(doctorList, "DoctorID", "LastName");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Token t)
        {
            List<Doctor> doctorList = db.Doctors.ToList();
            ViewBag.doctorlst = new SelectList(doctorList, "DoctorID", "LastName");

            if (t != null)
            {
                Random r = new Random();
                int num = r.Next();
                t.UniqueToken = num.ToString();

                TempData["tokenNumber"] = num.ToString();

                db.Tokens.Add(t);
                db.SaveChanges();
            }
            else
            {
                TempData["tokenNumber"] = "token failed";
            }
         
            return View();
        }

        public JsonResult GetReport(DateTime str, DateTime end)
        {
            db.Configuration.ProxyCreationEnabled = false;

            // select * from token where date between  '' and ''
            var query = from x in db.token_details where x.TokenDate >= str && x.TokenDate <= end select x;

            return Json(query,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reporting()
        {
            return View();
        }
	}
}