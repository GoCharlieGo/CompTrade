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
    public class ProductIconsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductIcons
        public ActionResult Index()
        {
            var productIcon = db.ProductIcon.Include(p => p.Icon).Include(p => p.Product);
            return View(productIcon.ToList());
        }

        // GET: ProductIcons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIcon productIcon = db.ProductIcon.Find(id);
            if (productIcon == null)
            {
                return HttpNotFound();
            }
            return View(productIcon);
        }

        // GET: ProductIcons/Create
        public ActionResult Create()
        {
            ViewBag.IconId = new SelectList(db.Icon, "Id", "IconPath");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            return View();
        }

        // POST: ProductIcons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,IconId")] ProductIcon productIcon)
        {
            if (ModelState.IsValid)
            {
                db.ProductIcon.Add(productIcon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IconId = new SelectList(db.Icon, "Id", "IconPath", productIcon.IconId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productIcon.ProductId);
            return View(productIcon);
        }

        // GET: ProductIcons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIcon productIcon = db.ProductIcon.Find(id);
            if (productIcon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IconId = new SelectList(db.Icon, "Id", "IconPath", productIcon.IconId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productIcon.ProductId);
            return View(productIcon);
        }

        // POST: ProductIcons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,IconId")] ProductIcon productIcon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productIcon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IconId = new SelectList(db.Icon, "Id", "IconPath", productIcon.IconId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", productIcon.ProductId);
            return View(productIcon);
        }

        // GET: ProductIcons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIcon productIcon = db.ProductIcon.Find(id);
            if (productIcon == null)
            {
                return HttpNotFound();
            }
            return View(productIcon);
        }

        // POST: ProductIcons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductIcon productIcon = db.ProductIcon.Find(id);
            db.ProductIcon.Remove(productIcon);
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
