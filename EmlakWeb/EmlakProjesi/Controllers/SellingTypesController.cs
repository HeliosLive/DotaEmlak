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
    public class SellingTypesController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: SellingTypes
        public ActionResult Index()
        {
            return View(db.Tbl_SellingType.ToList());
        }

        // GET: SellingTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingType sellingType = db.Tbl_SellingType.Find(id);
            if (sellingType == null)
            {
                return HttpNotFound();
            }
            return View(sellingType);
        }

        // GET: SellingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,CreateTime,Active")] SellingType sellingType)
        {
            if (ModelState.IsValid)
            {
                sellingType.CreateTime = DateTime.Now;
                db.Tbl_SellingType.Add(sellingType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellingType);
        }

        // GET: SellingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingType sellingType = db.Tbl_SellingType.Find(id);
            if (sellingType == null)
            {
                return HttpNotFound();
            }
            return View(sellingType);
        }

        // POST: SellingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,CreateTime,Active")] SellingType sellingType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellingType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellingType);
        }

        // GET: SellingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingType sellingType = db.Tbl_SellingType.Find(id);
            if (sellingType == null)
            {
                return HttpNotFound();
            }
            return View(sellingType);
        }

        // POST: SellingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellingType sellingType = db.Tbl_SellingType.Find(id);
            db.Tbl_SellingType.Remove(sellingType);
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
