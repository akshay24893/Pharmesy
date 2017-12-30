using Pharmeasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmeasy.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        private PharmeasyModel db = new PharmeasyModel();
        // GET: Reqprescp
        public ActionResult ReqPre()
        {
            return View(db.UserDatas.ToList());
        }
        [HttpPost]
        public ActionResult ReqPre(string email)
        {
            List<UserData> l = db.UserDatas.Where(u => u.usr_email.Equals(email)).ToList();
            return View(l);
        }
        public ActionResult Select(int? id)
        {
            int reqid = (int)Session["UserID"];
            string usr = (string)Session["user"];
            if (usr.Equals("DoctorDatas"))
            {
                db.Approvals.Add(new Approval() { user_id = id, doc_id = reqid });
            }
            if (usr.Equals("Pharmacists"))
            {
                db.Approvals.Add(new Approval() { user_id = id, pharmacist_id = reqid });
            }
            db.SaveChanges();
            TempData["Success"] = "Request sent to patiiant!";

            return RedirectToAction("ReqPre");
        }
    }
}