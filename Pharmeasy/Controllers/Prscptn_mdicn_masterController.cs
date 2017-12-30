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
    public class Prscptn_mdicn_masterController : Controller
    {
        private PharmeasyModel db = new PharmeasyModel();

        // GET: Prscptn_mdicn_master
        public ActionResult Index()
        {
            var prscptn_mdicn_master = db.Prscptn_mdicn_master.Include(p => p.Medicine).Include(p => p.Prescription);
            return View(prscptn_mdicn_master.ToList());
        }

        // GET: Prscptn_mdicn_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prscptn_mdicn_master prscptn_mdicn_master = db.Prscptn_mdicn_master.Find(id);
            if (prscptn_mdicn_master == null)
            {
                return HttpNotFound();
            }
            return View(prscptn_mdicn_master);
        }

        // GET: Prscptn_mdicn_master/Create
        public ActionResult Create()
        {
            ViewBag.medicine_id = new SelectList(db.Medicines, "medicine_id", "medicine_name");
            ViewBag.presciption_id = new SelectList(db.Prescriptions, "presciption_id", "treatment");
            return View();
        }

        // POST: Prscptn_mdicn_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prscptn_mdicn_masters_id,presciption_id,medicine_id")] Prscptn_mdicn_master prscptn_mdicn_master)
        {
            if (ModelState.IsValid)
            {
                db.Prscptn_mdicn_master.Add(prscptn_mdicn_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicine_id = new SelectList(db.Medicines, "medicine_id", "medicine_name", prscptn_mdicn_master.medicine_id);
            ViewBag.presciption_id = new SelectList(db.Prescriptions, "presciption_id", "treatment", prscptn_mdicn_master.presciption_id);
            return View(prscptn_mdicn_master);
        }

        // GET: Prscptn_mdicn_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prscptn_mdicn_master prscptn_mdicn_master = db.Prscptn_mdicn_master.Find(id);
            if (prscptn_mdicn_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicine_id = new SelectList(db.Medicines, "medicine_id", "medicine_name", prscptn_mdicn_master.medicine_id);
            ViewBag.presciption_id = new SelectList(db.Prescriptions, "presciption_id", "treatment", prscptn_mdicn_master.presciption_id);
            return View(prscptn_mdicn_master);
        }

        // POST: Prscptn_mdicn_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prscptn_mdicn_masters_id,presciption_id,medicine_id")] Prscptn_mdicn_master prscptn_mdicn_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prscptn_mdicn_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicine_id = new SelectList(db.Medicines, "medicine_id", "medicine_name", prscptn_mdicn_master.medicine_id);
            ViewBag.presciption_id = new SelectList(db.Prescriptions, "presciption_id", "treatment", prscptn_mdicn_master.presciption_id);
            return View(prscptn_mdicn_master);
        }

        // GET: Prscptn_mdicn_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prscptn_mdicn_master prscptn_mdicn_master = db.Prscptn_mdicn_master.Find(id);
            if (prscptn_mdicn_master == null)
            {
                return HttpNotFound();
            }
            return View(prscptn_mdicn_master);
        }

        // POST: Prscptn_mdicn_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prscptn_mdicn_master prscptn_mdicn_master = db.Prscptn_mdicn_master.Find(id);
            db.Prscptn_mdicn_master.Remove(prscptn_mdicn_master);
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
