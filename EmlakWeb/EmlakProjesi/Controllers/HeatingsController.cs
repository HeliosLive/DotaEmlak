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
    public class HeatingsController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: Heatings
        public ActionResult Index()
        {
            return View(db.Tbl_Heating.ToList());
        }

        // GET: Heatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heating heating = db.Tbl_Heating.Find(id);
            if (heating == null)
            {
                return HttpNotFound();
            }
            return View(heating);
        }

        // GET: Heatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Heatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,CreateTime,Active")] Heating heating)
        {
            if (ModelState.IsValid)
            {
                heating.CreateTime = DateTime.Now;
                db.Tbl_Heating.Add(heating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heating);
        }

        // GET: Heatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heating heating = db.Tbl_Heating.Find(id);
            if (heating == null)
            {
                return HttpNotFound();
            }
            return View(heating);
        }

        // POST: Heatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,CreateTime,Active")] Heating heating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heating);
        }

        // GET: Heatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heating heating = db.Tbl_Heating.Find(id);
            if (heating == null)
            {
                return HttpNotFound();
            }
            return View(heating);
        }

        // POST: Heatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heating heating = db.Tbl_Heating.Find(id);
            db.Tbl_Heating.Remove(heating);
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
