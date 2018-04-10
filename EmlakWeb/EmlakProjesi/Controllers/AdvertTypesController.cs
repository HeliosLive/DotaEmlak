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
    public class AdvertTypesController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: AdvertTypes
        public ActionResult Index()
        {
            return View(db.Tbl_AdvertType.ToList());
        }

        // GET: AdvertTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertType advertType = db.Tbl_AdvertType.Find(id);
            if (advertType == null)
            {
                return HttpNotFound();
            }
            return View(advertType);
        }

        // GET: AdvertTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AdvertId,Premium,StartDate,EndDate,UpdateDate")] AdvertType advertType)
        {
            advertType.EndDate = DateTime.Now.AddDays(15);
            advertType.StartDate = DateTime.Now;
            advertType.UpdateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Tbl_AdvertType.Add(advertType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertType);
        }

        // GET: AdvertTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertType advertType = db.Tbl_AdvertType.Find(id);
            if (advertType == null)
            {
                return HttpNotFound();
            }
            return View(advertType);
        }

        // POST: AdvertTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AdvertId,Premium,StartDate,EndDate,UpdateDate")] AdvertType advertType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertType);
        }

        // GET: AdvertTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertType advertType = db.Tbl_AdvertType.Find(id);
            if (advertType == null)
            {
                return HttpNotFound();
            }
            return View(advertType);
        }

        // POST: AdvertTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvertType advertType = db.Tbl_AdvertType.Find(id);
            db.Tbl_AdvertType.Remove(advertType);
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
