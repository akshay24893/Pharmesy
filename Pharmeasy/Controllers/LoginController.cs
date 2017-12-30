using Pharmeasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmeasy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private PharmeasyModel db = new PharmeasyModel();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["user"] = null;
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password,user")] LoginModel login)
        {
            int idn;
            if (ModelState.IsValid)

            {
                idn = login.IsValid(login.UserName, login.Password, login.user);
                if (idn > 0)
                {
                    Session["UserID"] = idn;
                    Session["UserName"] = login.UserName.ToString();
                    Session["user"] = login.user.ToString();
                    return RedirectToAction("Details", login.user, new { id = idn });
                }
                else
                {
                    ModelState.AddModelError("", " name or password is incorrect.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please Enter name or password.");
            }
            return View(login);
        }
    }
}