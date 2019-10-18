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
    public class ApplesController : Controller
    {
        private Agriculture_DatabaseEntities db = new Agriculture_DatabaseEntities();

        // GET: Apples
        public ActionResult Index()
        {
            var apples = db.Apples.Include(a => a.Fruit);
            return View(apples.ToList());
        }

        // GET: Apples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple apple = db.Apples.Find(id);
            if (apple == null)
            {
                return HttpNotFound();
            }
            return View(apple);
        }

        // GET: Apples/Create
        public ActionResult Create()
        {
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name");
            return View();
        }

        // POST: Apples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Form_ID,Fruit_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Apple apple)
        {
            if (ModelState.IsValid)
            {
                db.Apples.Add(apple);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", apple.Fruit_ID);
            return View(apple);
        }

        // GET: Apples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple apple = db.Apples.Find(id);
            if (apple == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", apple.Fruit_ID);
            return View(apple);
        }

        // POST: Apples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Form_ID,Fruit_ID,Form,Average_Retail_Price_Dollars,Price_Unit,Preparation_yield_Factor,Size_Cup_Equivalent,Size_Unit,Average_Price_Per_Cup_Dollars")] Apple apple)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apple).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fruit_ID = new SelectList(db.Fruits, "Fruit_ID", "Fruit_Name", apple.Fruit_ID);
            return View(apple);
        }

        // GET: Apples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apple apple = db.Apples.Find(id);
            if (apple == null)
            {
                return HttpNotFound();
            }
            return View(apple);
        }

        // POST: Apples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apple apple = db.Apples.Find(id);
            db.Apples.Remove(apple);
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
