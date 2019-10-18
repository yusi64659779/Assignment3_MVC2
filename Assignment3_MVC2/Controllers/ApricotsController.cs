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
    public class ApricotsController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Apricots
        public ActionResult Index()
        {
            var apricots = db.Apricots.Include(a => a.Fruit);
            return View(apricots.ToList());
        }

        // GET: Apricots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apricot apricot = db.Apricots.Find(id);
            if (apricot == null)
            {
                return HttpNotFound();
            }
            return View(apricot);
        }

        // GET: Apricots/Create
        public ActionResult Create()
        {
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name");
            return View();
        }

        // POST: Apricots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form_ID,Fruit_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Apricot apricot)
        {
            if (ModelState.IsValid)
            {
                db.Apricots.Add(apricot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", apricot.Fruit_ID);
            return View(apricot);
        }

        // GET: Apricots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apricot apricot = db.Apricots.Find(id);
            if (apricot == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", apricot.Fruit_ID);
            return View(apricot);
        }

        // POST: Apricots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form_ID,Fruit_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Apricot apricot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apricot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", apricot.Fruit_ID);
            return View(apricot);
        }

        // GET: Apricots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apricot apricot = db.Apricots.Find(id);
            if (apricot == null)
            {
                return HttpNotFound();
            }
            return View(apricot);
        }

        // POST: Apricots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apricot apricot = db.Apricots.Find(id);
            db.Apricots.Remove(apricot);
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
