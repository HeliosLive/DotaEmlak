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
    public class UsersController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: Users
        public ActionResult Index()
        {
            var tbl_User = db.Tbl_User;
            return View(tbl_User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Tbl_User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name");
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,Soyad,EMail,TelNo,Adres,CityId,DistrictId,CreateTime,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreateTime = DateTime.Now;
                db.Tbl_User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name", user.CityId);
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name", user.DistrictId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Tbl_User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name", user.CityId);
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name", user.DistrictId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Soyad,EMail,TelNo,Adres,CityId,DistrictId,CreateTime,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name", user.CityId);
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name", user.DistrictId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Tbl_User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Tbl_User.Find(id);
            db.Tbl_User.Remove(user);
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
