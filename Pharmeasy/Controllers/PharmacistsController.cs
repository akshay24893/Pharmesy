﻿using System;
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
    public class PharmacistsController : Controller
    {
        private PharmeasyModel db = new PharmeasyModel();

        // GET: Pharmacists
        public ActionResult Index()
        {
            return View(db.Pharmacists.ToList());
        }

        // GET: Pharmacists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacist pharmacist = db.Pharmacists.Find(id);
            if (pharmacist == null)
            {
                return HttpNotFound();
            }
            return View(pharmacist);
        }

        // GET: Pharmacists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pharmacist_id,fname,lname,mobile,ph_email,password")] Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                db.Pharmacists.Add(pharmacist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pharmacist);
        }

        // GET: Pharmacists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacist pharmacist = db.Pharmacists.Find(id);
            if (pharmacist == null)
            {
                return HttpNotFound();
            }
            return View(pharmacist);
        }

        // POST: Pharmacists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pharmacist_id,fname,lname,mobile,ph_email,password")] Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharmacist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pharmacist);
        }

        // GET: Pharmacists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacist pharmacist = db.Pharmacists.Find(id);
            if (pharmacist == null)
            {
                return HttpNotFound();
            }
            return View(pharmacist);
        }

        // POST: Pharmacists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pharmacist pharmacist = db.Pharmacists.Find(id);
            db.Pharmacists.Remove(pharmacist);
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