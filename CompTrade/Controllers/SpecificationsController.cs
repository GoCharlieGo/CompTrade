using System;
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
    public class SpecificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Specifications
        public ActionResult Index()
        {
            var specifications = db.Specifications.Include(s => s.Category);
            return View(specifications.ToList());
        }

        // GET: Specifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            return View(specification);
        }

        // GET: Specifications/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categoryes, "Id", "CategoryName");
            return View();
        }

        // POST: Specifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,CategoryId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Specifications.Add(specification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categoryes, "Id", "CategoryName", specification.CategoryId);
            return View(specification);
        }

        // GET: Specifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categoryes, "Id", "CategoryName", specification.CategoryId);
            return View(specification);
        }

        // POST: Specifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,CategoryId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categoryes, "Id", "CategoryName", specification.CategoryId);
            return View(specification);
        }

        // GET: Specifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specification specification = db.Specifications.Find(id);
            if (specification == null)
            {
                return HttpNotFound();
            }
            return View(specification);
        }

        // POST: Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specification specification = db.Specifications.Find(id);
            db.Specifications.Remove(specification);
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
