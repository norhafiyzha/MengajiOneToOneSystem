using MengajiOneToOneSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengajiOneToOneSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MengajiOneToOneSystem.Models.Admin adminModel)
        {
            using(db_motoEntities db = new db_motoEntities())
            {
                var adminDetails = db.Admins.Where(x => x.a_id == adminModel.a_id && x.a_password == adminModel.a_password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = " ID Pengguna atau Kata Laluan Tidak Tepat";
                    return View("Login",adminModel);
                }
                else
                {
                    Session["adminID"] = adminDetails.a_id;
                    return RedirectToAction("Dashboard","Admin");
                }
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}