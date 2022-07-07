using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeacherandParentsAssoc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult LoginUser(string EmployeeNumber, string Password, string millName)
        {
            var result = new { Result = "fail", ID = "" };
            if (EmployeeNumber == "prof1" && Password == "prof1")
            {
                Session["admin"] = "adminsettings";
                Session["user"] = "Prof 1";
                result = new { Result = "Legit", ID = "" };
            }
            else if (EmployeeNumber == "parent" && Password == "parent")
            {
                Session["operator"] = "operatorsettings";
                Session["admin"] = "";
                Session["user"] = "Parent";
                result = new { Result = "Legit", ID = "" };

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index");

        }
    }
}