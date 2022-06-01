using MengajiOneToOneSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengajiOneToOneSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MengajiOneToOneSystem.Models.User uModel)
        {
            using (db_motoEntities db = new db_motoEntities())
            {
                var uDetails = db.Users.Where(x => x.u_id == uModel.u_id && x.u_password == uModel.u_password).FirstOrDefault();
                if (uDetails == null)
                {
                    uModel.LoginErrorMessage = " ID Pengguna atau Kata Laluan Tidak Tepat";
                    return View("Login", uModel);
                }
                else
                {
                    Session["userID"] = uDetails.u_id;
                    return RedirectToAction("Dashboard", "Student");
                }
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}