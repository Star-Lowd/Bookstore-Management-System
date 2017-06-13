using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class StaffController : Controller
    {
        //GET : Staff //List of all staff
        public ActionResult Index()
        {
            return View(AuthenticationModel.GetStaffs());
        }

        // GET: Staff
        public ActionResult ViewProfile(int id)
        {
            return View(AuthenticationModel.FindUser(id));
        }

        // GET: Staff/Details/5
        public ActionResult UpdateStaff(int id)
        {
            return View(AuthenticationModel.FindUser(id));
        }


        // POST: Staff/Details/5
        [HttpPost]
        public ActionResult UpdateStaff(int id, USER user)
        {
            if (ModelState.IsValid)
            {
                AuthenticationModel.UpdateUser(user);
                ViewBag.Message = ErrorMessage.USER_UPDATED;
            }
            else
            {
                ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
            }
            return View();
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            USER user = AuthenticationModel.FindUser(id);
            AuthenticationModel.DeleteUser(id);

            EmailNotification.AccountDeletedNotification(user);

            return RedirectToAction("index");
        }

    }
}
