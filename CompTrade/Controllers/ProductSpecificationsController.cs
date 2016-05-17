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
    public class ProductSpecificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductSpecifications
        public ActionResult Index()
        {
            var productSpecifications = db.ProductSpecifications.Include(p => p.Product).Include(p => p.Specification);
            return View(productSpecifications.ToList());
        }

        // GET: ProductSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpecification productSpecification = db.ProductSpecifications.Find(id);
            if (productSpecification == null)
            {
                return HttpNotFound();
            }
            return View(productSpecification);
        }

        // GET: ProductSpecifications/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.SpecificationId = new SelectList(db.Specifications, "Id", "CategoryName");
            return View();
        }

        // POST: ProductSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,SpecificationId,Value")] ProductSpecification productSpecification)
        {
            if (ModelState.IsValid)
            {
                db.ProductSpecifications.Add(productSpecification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productSpecification.ProductId);
            ViewBag.SpecificationId = new SelectList(db.Specifications, "Id", "CategoryName", productSpecification.SpecificationId);
            return View(productSpecification);
        }

        // GET: ProductSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpecification productSpecification = db.ProductSpecifications.Find(id);
            if (productSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productSpecification.ProductId);
            ViewBag.SpecificationId = new SelectList(db.Specifications, "Id", "CategoryName", productSpecification.SpecificationId);
            return View(productSpecification);
        }

        // POST: ProductSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,SpecificationId,Value")] ProductSpecification productSpecification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSpecification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productSpecification.ProductId);
            ViewBag.SpecificationId = new SelectList(db.Specifications, "Id", "CategoryName", productSpecification.SpecificationId);
            return View(productSpecification);
        }

        // GET: ProductSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpecification productSpecification = db.ProductSpecifications.Find(id);
            if (productSpecification == null)
            {
                return HttpNotFound();
            }
            return View(productSpecification);
        }

        // POST: ProductSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSpecification productSpecification = db.ProductSpecifications.Find(id);
            db.ProductSpecifications.Remove(productSpecification);
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
