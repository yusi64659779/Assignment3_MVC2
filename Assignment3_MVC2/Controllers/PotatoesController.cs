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
    public class PotatoesController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Potatoes
        public ActionResult Index()
        {
            var potatoes = db.Potatoes.Include(p => p.Vegetable);
            return View(potatoes.ToList());
        }

        // GET: Potatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potato potato = db.Potatoes.Find(id);
            if (potato == null)
            {
                return HttpNotFound();
            }
            return View(potato);
        }

        // GET: Potatoes/Create
        public ActionResult Create()
        {
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name");
            return View();
        }

        // POST: Potatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form_ID,Veg_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Potato potato)
        {
            if (ModelState.IsValid)
            {
                db.Potatoes.Add(potato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", potato.Veg_ID);
            return View(potato);
        }

        // GET: Potatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potato potato = db.Potatoes.Find(id);
            if (potato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", potato.Veg_ID);
            return View(potato);
        }

        // POST: Potatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form_ID,Veg_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Potato potato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", potato.Veg_ID);
            return View(potato);
        }

        // GET: Potatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potato potato = db.Potatoes.Find(id);
            if (potato == null)
            {
                return HttpNotFound();
            }
            return View(potato);
        }

        // POST: Potatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potato potato = db.Potatoes.Find(id);
            db.Potatoes.Remove(potato);
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
