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
    public class BlueberriesController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Blueberries
        public ActionResult Index()
        {
            var blueberries = db.Blueberries.Include(b => b.Fruit);
            return View(blueberries.ToList());
        }

        // GET: Blueberries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blueberry blueberry = db.Blueberries.Find(id);
            if (blueberry == null)
            {
                return HttpNotFound();
            }
            return View(blueberry);
        }

        // GET: Blueberries/Create
        public ActionResult Create()
        {
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name");
            return View();
        }

        // POST: Blueberries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form_ID,Fruit_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Blueberry blueberry)
        {
            if (ModelState.IsValid)
            {
                db.Blueberries.Add(blueberry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", blueberry.Fruit_ID);
            return View(blueberry);
        }

        // GET: Blueberries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blueberry blueberry = db.Blueberries.Find(id);
            if (blueberry == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", blueberry.Fruit_ID);
            return View(blueberry);
        }

        // POST: Blueberries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form_ID,Fruit_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Blueberry blueberry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blueberry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", blueberry.Fruit_ID);
            return View(blueberry);
        }

        // GET: Blueberries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blueberry blueberry = db.Blueberries.Find(id);
            if (blueberry == null)
            {
                return HttpNotFound();
            }
            return View(blueberry);
        }

        // POST: Blueberries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blueberry blueberry = db.Blueberries.Find(id);
            db.Blueberries.Remove(blueberry);
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
