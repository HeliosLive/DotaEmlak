using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmlakProjesi.Models;

namespace EmlakProjesi.Controllers
{
    public class PropertyTypesController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: PropertyTypes
        public ActionResult Index()
        {
            return View(db.Tbl_PropertyType.ToList());
        }

        // GET: PropertyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = db.Tbl_PropertyType.Find(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // GET: PropertyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,CreateTime,Active")] PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                propertyType.CreateTime = DateTime.Now;
                db.Tbl_PropertyType.Add(propertyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyType);
        }

        // GET: PropertyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = db.Tbl_PropertyType.Find(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,CreateTime,Active")] PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        // GET: PropertyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = db.Tbl_PropertyType.Find(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyType propertyType = db.Tbl_PropertyType.Find(id);
            db.Tbl_PropertyType.Remove(propertyType);
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
