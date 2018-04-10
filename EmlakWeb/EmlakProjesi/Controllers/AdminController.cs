using EmlakProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using System.Net;

namespace EmlakProjesi.Controllers
{
    public class AdminController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: Admin     
        public ActionResult Index(int? page, string sınıf)
        {
            if (Session["UserRole"] == null) { return RedirectToAction("Index", "Home"); }
            if (Session["UserRole"].ToString() != "2")
            {
                return RedirectToAction("Index", "Home");
            }
            var ilanlar = db.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
            Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
            Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
            //.Where(i => i.Active == false)
            .OrderByDescending(i => i.StartDate);

            ViewBag.ilansayisi = ilanlar.Count();
            ViewData["ilanlar"] = ilanlar.Where(i => i.Active == false && i.IsSold==false).ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "ilan")
            {
                int? ilpage = 1;
                ViewData["ilanlar"] = ilanlar.Where(i => i.Active == false && i.IsSold == false).ToList().ToPagedList(ilpage ?? 1, 4);
            }

            //
            ViewData["ilanlaronay"] = ilanlar.Where(i => i.Active == true).ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "ilanonay")
            {
                int? ilpage = 1;
                ViewData["ilanlaronay"] = ilanlar.Where(i => i.Active == true).ToList().ToPagedList(ilpage ?? 1, 4);
            }

            //
            ViewData["ilanlarsatis"] = ilanlar.Where(i => i.Active == false).ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "ilansatis")
            {
                int? ilpage = 1;
                ViewData["ilanlarsatis"] = ilanlar.Where(i => i.Active == false).ToList().ToPagedList(ilpage ?? 1, 4);
            }
            //

            var iller = db.Tbl_City.OrderBy(i => i.Name);
            ViewData["iller"] = iller.ToList().ToPagedList(page ?? 1, 4);
            ViewData["Cities"] = iller.ToList();

            if (sınıf != "il")
            {
                int ? ilpage = 1;
                ViewData["iller"] = iller.ToList().ToPagedList(ilpage ?? 1, 4); 
            }

            var ilceler = db.Tbl_District.OrderBy(i => i.Name);
            ViewData["ilceler"] = ilceler.ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "ilce")
            {
                int? ilcepage = 1;
                ViewData["ilceler"] = ilceler.ToList().ToPagedList(ilcepage ?? 1, 4); 
            }

            var isitmalar = db.Tbl_Heating.OrderBy(i => i.Ad);
            ViewData["isitmalar"] = isitmalar.ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "isitma")
            {
                int? isitmapage = 1;
                ViewData["isitmalar"] = isitmalar.ToList().ToPagedList(isitmapage ?? 1, 4); 
            }

            var satislar = db.Tbl_SellingType.OrderBy(i => i.Ad);
            ViewData["satislar"] = satislar.ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "satis")
            {
                int? satispage = 1;
                ViewData["satislar"] = satislar.ToList().ToPagedList(satispage ?? 1, 4); 
            }

            var emlaklar = db.Tbl_PropertyType.OrderBy(i => i.Ad);
            ViewData["emlaklar"] = emlaklar.ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "emlak")
            {
                int? emlakpage = 1;
                ViewData["emlaklar"] = emlaklar.ToList().ToPagedList(emlakpage ?? 1, 4); 
            }

            var odalar = db.Tbl_Room.OrderBy(i => i.Ad);
            ViewData["odalar"] = odalar.ToList().ToPagedList(page ?? 1, 4);

            if (sınıf != "oda")
            {
                int? odapage = 1;
                ViewData["odalar"] = odalar.ToList().ToPagedList(odapage ?? 1, 4); 
            }

            ViewBag.sınıf = sınıf;

            return View();
        }

        public ActionResult AdvertSell(int id)
        {
            Advert ads = db.Tbl_Advert.Find(id);

            if (ads == null)
            {
                return HttpNotFound();
            }
            ads.Active = false;
            ads.IsSold = true;
            ads.EndDate = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "ilansell" });
        }

        public ActionResult AdvertApproval(int id)
        {
            Advert ads = db.Tbl_Advert.Find(id);

            if (ads == null)
            {
                return HttpNotFound();
            }
            ads.Active = true;
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "ilan" });
        }

        public ActionResult AdvertDelete(int id)
        {
            Advert ads = db.Tbl_Advert.Find(id);

            if (ads == null)
            {
                return HttpNotFound();
            }
            db.Tbl_Advert.Remove(ads);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "ilan" });
        }


        [HttpPost]
        public ActionResult CityAdd(string city)
        {
            if (ModelState.IsValid)
            {
                City citi = new Models.City();
                citi.Name = city;
                citi.Active = true;
                citi.CreateTime = DateTime.Now;
                db.Tbl_City.Add(citi);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult CityDelete(int id)
        {
            City city = db.Tbl_City.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            db.Tbl_City.Remove(city);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "il" });
        }
         
        [HttpPost]
        public ActionResult DistrictAdd(string district,int cityid)
        {
            if (ModelState.IsValid)
            {
                District dist = new District();
                dist.Name = district;
                dist.Active = true;
                dist.CreateTime = DateTime.Now;
                var sehir = db.Tbl_City.Find(cityid);
                dist.CityName = sehir.Name;
                db.Tbl_District.Add(dist);
                db.SaveChanges(); 
            }

            return RedirectToAction("Index");
        }

        public ActionResult DistrictDelete(int id)
        {
            District dist = db.Tbl_District.Find(id);
            if (dist == null)
            {
                return HttpNotFound();
            }

            db.Tbl_District.Remove(dist);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "ilce" });
        }

        [HttpPost]
        public ActionResult HeatingAdd(string heating)
        {
            if (ModelState.IsValid)
            {
                Heating heat = new Heating();
                heat.Ad = heating;
                heat.Active = true;
                heat.CreateTime = DateTime.Now; 
                db.Tbl_Heating.Add(heat);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult HeatingDelete(int id)
        {
            Heating heat = db.Tbl_Heating.Find(id);
            if (heat == null)
            {
                return HttpNotFound();
            }

            db.Tbl_Heating.Remove(heat);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "isitma" });
        }

        [HttpPost]
        public ActionResult SellingAdd(string selling)
        {
            if (ModelState.IsValid)
            {
                SellingType sell = new SellingType();
                sell.Active = true;
                sell.CreateTime = DateTime.Now;
                sell.Ad = selling;

                db.Tbl_SellingType.Add(sell);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult SellingDelete(int id)
        {
            SellingType sell = db.Tbl_SellingType.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }

            db.Tbl_SellingType.Remove(sell);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "satis" });
        }

        [HttpPost]
        public ActionResult PropertyAdd(string property)
        {
            if (ModelState.IsValid)
            {
                PropertyType prop = new PropertyType();
                prop.Active = true;
                prop.CreateTime = DateTime.Now;
                prop.Ad = property;

                db.Tbl_PropertyType.Add(prop);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult PropertyDelete(int id)
        {
            PropertyType prop = db.Tbl_PropertyType.Find(id);
            if (prop == null)
            {
                return HttpNotFound();
            }

            db.Tbl_PropertyType.Remove(prop);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "emlak" });
        }

        [HttpPost]
        public ActionResult RoomAdd(string roomname)
        {
            if (ModelState.IsValid)
            {
                Room room = new Room();
                room.Active = true;
                room.CreateTime = DateTime.Now;
                room.Ad = roomname;

                db.Tbl_Room.Add(room);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult RoomDelete(int id)
        {
            Room room= db.Tbl_Room.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            db.Tbl_Room.Remove(room);
            db.SaveChanges();

            return RedirectToAction("Index", new { sınıf = "oda" });
        }
    }
}