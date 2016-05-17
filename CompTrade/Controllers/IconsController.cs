﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompTrade.Models;

namespace CompTrade.Controllers
{
    public class IconsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Icons
        public ActionResult Index()
        {
            return View(db.Icon.ToList());
        }

        // GET: Icons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icon icon = db.Icon.Find(id);
            if (icon == null)
            {
                return HttpNotFound();
            }
            return View(icon);
        }

        // GET: Icons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Icons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IconPath")] Icon icon)
        {
            if (ModelState.IsValid)
            {
                db.Icon.Add(icon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(icon);
        }

        // GET: Icons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icon icon = db.Icon.Find(id);
            if (icon == null)
            {
                return HttpNotFound();
            }
            return View(icon);
        }

        // POST: Icons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IconPath")] Icon icon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icon);
        }

        // GET: Icons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icon icon = db.Icon.Find(id);
            if (icon == null)
            {
                return HttpNotFound();
            }
            return View(icon);
        }

        // POST: Icons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Icon icon = db.Icon.Find(id);
            db.Icon.Remove(icon);
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