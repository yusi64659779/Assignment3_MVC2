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
    public class VegetablesController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Vegetables
        public ActionResult Index()
        {
            var vegetables = db.Vegetables.Include(v => v.Agri_Products);
            return View(vegetables.ToList());
        }

        // GET: Vegetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegetable vegetable = db.Vegetables.Find(id);
            if (vegetable == null)
            {
                return HttpNotFound();
            }
            return View(vegetable);
        }

        // GET: Vegetables/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Agri_Products, "Product_ID", "Product_Name");
            return View();
        }

        // POST: Vegetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Veg_ID,Product_ID,Veg_Name")] Vegetable vegetable)
        {
            if (ModelState.IsValid)
            {
                db.Vegetables.Add(vegetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.Agri_Products, "Product_ID", "Product_Name", vegetable.Product_ID);
            return View(vegetable);
        }

        // GET: Vegetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegetable vegetable = db.Vegetables.Find(id);
            if (vegetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.Agri_Products, "Product_ID", "Product_Name", vegetable.Product_ID);
            return View(vegetable);
        }

        // POST: Vegetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Veg_ID,Product_ID,Veg_Name")] Vegetable vegetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vegetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.Agri_Products, "Product_ID", "Product_Name", vegetable.Product_ID);
            return View(vegetable);
        }

        // GET: Vegetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegetable vegetable = db.Vegetables.Find(id);
            if (vegetable == null)
            {
                return HttpNotFound();
            }
            return View(vegetable);
        }

        // POST: Vegetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vegetable vegetable = db.Vegetables.Find(id);
            db.Vegetables.Remove(vegetable);
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
