using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmeasy.Models;

namespace Pharmeasy.Models
{
    public class ShowPrescreptionController : Controller
    {

        private PharmeasyModel db = new PharmeasyModel();
        // GET: ShowPrescreption
        public ActionResult PreScrpt()
        {
            int id=(int)Session["UserID"];
            string usr=(string)Session["user"];
            if(usr.Equals("Pharmacists"))
            {
                var val =(from a in db.Approvals.Where(a => a.app_ph == id)
                          join c in db.Prescriptions on a.user_id equals c.user_id select c).ToList();

                return View(val);
            }
            if (usr.Equals("DoctorDatas"))
            {
                var val = (from a in db.Approvals.Where(a => a.app_doc == id)
                           join c in db.Prescriptions on a.user_id equals c.user_id
                           select c).ToList();

                return View(val);
            }
            return View();
        }
        
        public ActionResult Select(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Pre = db.Prscptn_mdicn_master.Where(a=>a.presciption_id==id).Include(p => p.Medicine).Include(p => p.Prescription).ToList();
            if (Pre == null)
            {
                return HttpNotFound();
            }
            return View(Pre);
        }
    }
}