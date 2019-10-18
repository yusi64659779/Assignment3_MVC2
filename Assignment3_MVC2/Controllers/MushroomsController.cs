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
    public class MushroomsController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Mushrooms
        public ActionResult Index()
        {
            var mushrooms = db.Mushrooms.Include(m => m.Vegetable);
            return View(mushrooms.ToList());
        }

        // GET: Mushrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mushroom mushroom = db.Mushrooms.Find(id);
            if (mushroom == null)
            {
                return HttpNotFound();
            }
            return View(mushroom);
        }

        // GET: Mushrooms/Create
        public ActionResult Create()
        {
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name");
            return View();
        }

        // POST: Mushrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form_ID,Veg_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Mushroom mushroom)
        {
            if (ModelState.IsValid)
            {
                db.Mushrooms.Add(mushroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", mushroom.Veg_ID);
            return View(mushroom);
        }

        // GET: Mushrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mushroom mushroom = db.Mushrooms.Find(id);
            if (mushroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", mushroom.Veg_ID);
            return View(mushroom);
        }

        // POST: Mushrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form_ID,Veg_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Mushroom mushroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mushroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Veg_ID = new SelectList(db.Vegetables, "Veg_ID", "Veg_Name", mushroom.Veg_ID);
            return View(mushroom);
        }

        // GET: Mushrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mushroom mushroom = db.Mushrooms.Find(id);
            if (mushroom == null)
            {
                return HttpNotFound();
            }
            return View(mushroom);
        }

        // POST: Mushrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mushroom mushroom = db.Mushrooms.Find(id);
            db.Mushrooms.Remove(mushroom);
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
