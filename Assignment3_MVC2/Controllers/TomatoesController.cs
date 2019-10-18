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
    public class TomatoesController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Tomatoes
        public ActionResult Index()
        {
            var tomatoes = db.Tomatoes.Include(t => t.Vegetable);
            return View(tomatoes.ToList());
        }

        // GET: Tomatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tomato tomato = db.Tomatoes.Find(id);
            if (tomato == null)
            {
                return HttpNotFound();
            }
            return View(tomato);
        }

        // GET: Tomatoes/Create
        public ActionResult Create()
        {
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name");
            return View();
        }

        // POST: Tomatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form_ID,Veg_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Tomato tomato)
        {
            if (ModelState.IsValid)
            {
                db.Tomatoes.Add(tomato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", tomato.Veg_ID);
            return View(tomato);
        }

        // GET: Tomatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tomato tomato = db.Tomatoes.Find(id);
            if (tomato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", tomato.Veg_ID);
            return View(tomato);
        }

        // POST: Tomatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form_ID,Veg_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Tomato tomato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tomato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", tomato.Veg_ID);
            return View(tomato);
        }

        // GET: Tomatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tomato tomato = db.Tomatoes.Find(id);
            if (tomato == null)
            {
                return HttpNotFound();
            }
            return View(tomato);
        }

        // POST: Tomatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tomato tomato = db.Tomatoes.Find(id);
            db.Tomatoes.Remove(tomato);
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
