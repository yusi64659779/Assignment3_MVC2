using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3_MVC2.Models;

namespace Assignment3_MVC2.Controllers
{
    public class Agri_ProductsController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Agri_Products
        public ActionResult Index()
        {
            return View(db.Agri_Products.ToList());
        }

        // GET: Agri_Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agri_Products agri_Products = db.Agri_Products.Find(id);
            if (agri_Products == null)
            {
                return HttpNotFound();
            }
            return View(agri_Products);
        }

        // GET: Agri_Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agri_Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Product_Name")] Agri_Products agri_Products)
        {
            if (ModelState.IsValid)
            {
                db.Agri_Products.Add(agri_Products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agri_Products);
        }

        // GET: Agri_Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agri_Products agri_Products = db.Agri_Products.Find(id);
            if (agri_Products == null)
            {
                return HttpNotFound();
            }
            return View(agri_Products);
        }

        // POST: Agri_Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Product_Name")] Agri_Products agri_Products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agri_Products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agri_Products);
        }

        // GET: Agri_Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agri_Products agri_Products = db.Agri_Products.Find(id);
            if (agri_Products == null)
            {
                return HttpNotFound();
            }
            return View(agri_Products);
        }

        // POST: Agri_Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agri_Products agri_Products = db.Agri_Products.Find(id);
            db.Agri_Products.Remove(agri_Products);
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
