using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smallclinicMVC.Models;

namespace smallclinicMVC.Controllers
{
    public class AccountController : Controller
    {
        dbClinicSystemEntities db = new dbClinicSystemEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var query = db.Users.Where(m => m.Email == Email && m.Password == Password).SingleOrDefault();

            if (query != null)
            {
                Session["UserID"] = query.UserID;
                Session["Email"] = query.Email;
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["msg"] = "Invalid Email & password";
            }

            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
	}
}