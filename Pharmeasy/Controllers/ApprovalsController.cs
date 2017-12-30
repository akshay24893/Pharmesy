using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmeasy.Models;

namespace Pharmeasy.Controllers
{
    public class ApprovalsController : Controller
    {
        private PharmeasyModel db = new PharmeasyModel();
        
        public ActionResult Grant(int? id)
        {
            Approval ap= db.Approvals.Find(id);
            if(ap.doc_id!=null)
            {
                ap.app_doc = ap.doc_id;
            }
            if(ap.pharmacist_id!=null)
            {
                ap.app_ph = ap.pharmacist_id;
            }
            db.Entry(ap).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Revoke(int? id)
        {
            Approval ap = db.Approvals.Find(id);
            if (ap.doc_id != null)
            {
                ap.app_doc = null;
            }
            if (ap.pharmacist_id != null)
            {
                ap.app_ph = null;
            }
            db.Entry(ap).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Approvals
        public ActionResult Index()
        {
            return View(db.Approvals.Include(a => a.DoctorData).Include(a => a.Pharmacist).Include(a => a.UserData).ToList().Where(a => a.user_id == (int)Session["UserID"]));
        }
        
        // GET: Approvals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            
            return View(approval);
        }

        // GET: Approvals/Create
        public ActionResult Create()
        {
            ViewBag.doc_id = new SelectList(db.DoctorDatas, "doc_id", "fname");
            ViewBag.pharmacist_id = new SelectList(db.Pharmacists, "pharmacist_id", "fname");
            ViewBag.user_id = new SelectList(db.UserDatas, "user_id", "fname");
            return View();
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "approval_id,user_id,app_doc,app_ph,doc_id,pharmacist_id")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Approvals.Add(approval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doc_id = new SelectList(db.DoctorDatas, "doc_id", "fname", approval.doc_id);
            ViewBag.pharmacist_id = new SelectList(db.Pharmacists, "pharmacist_id", "fname", approval.pharmacist_id);
            ViewBag.user_id = new SelectList(db.UserDatas, "user_id", "fname", approval.user_id);
            return View(approval);
        }

        // GET: Approvals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            ViewBag.doc_id = new SelectList(db.DoctorDatas, "doc_id", "fname", approval.doc_id);
            ViewBag.pharmacist_id = new SelectList(db.Pharmacists, "pharmacist_id", "fname", approval.pharmacist_id);
            ViewBag.user_id = new SelectList(db.UserDatas, "user_id", "fname", approval.user_id);
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "approval_id,user_id,app_doc,app_ph,doc_id,pharmacist_id")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doc_id = new SelectList(db.DoctorDatas, "doc_id", "fname", approval.doc_id);
            ViewBag.pharmacist_id = new SelectList(db.Pharmacists, "pharmacist_id", "fname", approval.pharmacist_id);
            ViewBag.user_id = new SelectList(db.UserDatas, "user_id", "fname", approval.user_id);
            return View(approval);
        }

        // GET: Approvals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Approval approval = db.Approvals.Find(id);
            db.Approvals.Remove(approval);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
