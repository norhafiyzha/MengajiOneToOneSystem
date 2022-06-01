using MengajiOneToOneSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengajiOneToOneSystem.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MengajiOneToOneSystem.Models.Teacher tModel)
        {
            using (db_motoEntities db = new db_motoEntities())
            {
                var tDetails = db.Teachers.Where(x => x.t_id == tModel.t_id && x.t_password == tModel.t_password).FirstOrDefault();
                if (tDetails == null)
                {
                    tModel.LoginErrorMessage = " ID Pengguna atau Kata Laluan Tidak Tepat";
                    return View("Login", tModel);
                }
                else
                {
                    Session["teacherID"] = tDetails.t_id;
                    return RedirectToAction("Dashboard", "Teacher");
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