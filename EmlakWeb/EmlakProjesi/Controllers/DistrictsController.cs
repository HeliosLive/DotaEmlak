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
    public class DistrictsController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: Districts
        public ActionResult Index()
        {
            //var ilceler = db.Tbl_District.ToList();
            //var il= ilceler.Select(i => i.CityId);
            //ViewBag.CityName = db.Tbl_City.Find(il);
            ////City c = db.Tbl_City.Find();
            ////ViewBag.kategories = kategori.KategoriAdi;
            ////ViewBag.CityName = new SelectList(db.Tbl_City, "ID", "Name");
            ////var ilceler = db.Tbl_District.Include(b => b.sehir);
            return View(db.Tbl_District.ToList());
            //return View(ilceler.ToList());

        }

        // GET: Districts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Tbl_District.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: Districts/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CityId,CityName,CreateTime,Active")] District district)
        {
            if (ModelState.IsValid)
            {
                district.CreateTime = DateTime.Now;
                var sehir = db.Tbl_City.Find(district.CityId);
                district.CityName = sehir.Name;
                db.Tbl_District.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(district);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Tbl_District.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CityId,CityName,CreateTime,Active")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(district);
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Tbl_District.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Tbl_District.Find(id);
            db.Tbl_District.Remove(district);
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
