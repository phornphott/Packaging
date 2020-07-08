using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            if (Session["iuserid"] == null)
            {
                return RedirectToAction("Login");
            }
            else {
                return View();
            }
               
        }
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult  Dashboard()
        {
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


        public ActionResult Authorization(string UserName, string Password) {
            UserData user = new UserData();
            USR item = new USR();
            bool chk = user.GetAuthorization(out item,UserName, Password);
            Library.GBuserID = 0;
            if (chk == true)
            {
                Library.GBuserID = item.USR_Id;
                Session["iuserid"] = item.USR_Id ;
                Session["iusername"] = item.USR_NameT;
                return RedirectToAction("Index");
            }
            else {

                TempData["error"] = "กรุณากรอกรหัสผู้ใช้และรหัสผ่าน";
                return RedirectToAction("Login");
            }
            
        }
    }
}