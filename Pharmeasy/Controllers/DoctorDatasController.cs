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
    public class DoctorDatasController : Controller
    {
        private PharmeasyModel db = new PharmeasyModel();

        // GET: DoctorDatas
        public ActionResult Index()
        {
            return View(db.DoctorDatas.ToList());
        }

        // GET: DoctorDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorData doctorData = db.DoctorDatas.Find(id);
            if (doctorData == null)
            {
                return HttpNotFound();
            }
            return View(doctorData);
        }

        // GET: DoctorDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doc_id,fname,lname,mobile,doc_email,password")] DoctorData doctorData)
        {
            if (ModelState.IsValid)
            {
                db.DoctorDatas.Add(doctorData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorData);
        }

        // GET: DoctorDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorData doctorData = db.DoctorDatas.Find(id);
            if (doctorData == null)
            {
                return HttpNotFound();
            }
            return View(doctorData);
        }

        // POST: DoctorDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doc_id,fname,lname,mobile,doc_email,password")] DoctorData doctorData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorData);
        }

        // GET: DoctorDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorData doctorData = db.DoctorDatas.Find(id);
            if (doctorData == null)
            {
                return HttpNotFound();
            }
            return View(doctorData);
        }

        // POST: DoctorDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorData doctorData = db.DoctorDatas.Find(id);
            db.DoctorDatas.Remove(doctorData);
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
