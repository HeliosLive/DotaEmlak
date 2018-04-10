using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmlakProjesi.Models;
using System.IO;

namespace EmlakProjesi.Controllers
{
    public class AdvertController : Controller
    {
        private AdvertContext db = new AdvertContext();

        // GET: Advert
        public ActionResult Index(string newadvertid)
        {
            ViewBag.newadvertid = newadvertid;

            var tbl_Advert = db.Tbl_Advert.Include(a => a.EmlakTipi).Include(a => a.il).Include(a => a.ilantipi).Include(a => a.ilce).Include(a => a.isitmatipi).Include(a => a.kacoda).Include(a => a.SatisTipi).Include(a => a.User);

            return View(tbl_Advert.ToList());
        }

        // GET: Advert/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

             ViewData["_PCityId"] = db.Tbl_City.ToList();
             ViewData["_PRoomId"] = db.Tbl_Room.ToList();
             ViewData["_PSellingTypeId"] = db.Tbl_SellingType.ToList();
             ViewData["_PHeatingTypeId"] = db.Tbl_Heating.ToList();

             ViewData["detayoneri"]=db.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
             Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
             Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
             .Where(i => i.Active == true)
             .OrderByDescending(i => i.StartDate).ToList().Take(7);

             Advert advert = db.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
             Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
             Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi).
             FirstOrDefault(x=>x.ID==id); 
            
            var Qualification = db.Tbl_Qualification.Where(i=>i.AdvertId==advert.ID).ToList();
            ViewData["Qualification"] = Qualification;
            ViewBag.Qualif = Qualification;
            if (Qualification == null && Qualification.ToString() =="")
            {
                return HttpNotFound();
            }
            var Resimler = db.Tbl_Image.Where(i => i.AdvertId == advert.ID).ToList();
            ViewData["Resimler"] = Resimler;
            if (Resimler == null && Resimler.ToString() == "")
            {
                return HttpNotFound();
            }
            if (advert == null)
            {
                return HttpNotFound();
            }

            advert.ViewCounter++;
            db.SaveChanges();
            return View(advert);
        }

        public ActionResult DetailAdvertMap()
        {
            return View();
        }
        

        // GET: Advert/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null && Session["Username"] == null)
            { return RedirectToAction("Login", "Account",new { response =2}); }

            var randomfilename = Path.GetRandomFileName();
            var date = DateTime.Now;
            ViewBag.SessionRandomId = "Kayıt Session: " + randomfilename + "_" + date;

            ViewBag.PropertyTypeId = new SelectList(db.Tbl_PropertyType, "ID", "Ad");
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name");
            ViewBag.AdvertTypeId = new SelectList(db.Tbl_AdvertType, "ID", "ID");
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name");
            ViewBag.HeatingId = new SelectList(db.Tbl_Heating, "ID", "Ad");
            ViewBag.RoomId = new SelectList(db.Tbl_Room, "ID", "Ad");
            ViewBag.SellingTypeId = new SelectList(db.Tbl_SellingType, "ID", "Ad");
            ViewBag.UserId = new SelectList(db.Tbl_User, "ID", "Ad");
            return View();
        }

        // POST: Advert/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public ActionResult AnaResim(HttpPostedFileBase[] files, string Id)   //HttpPostedFileBase[] files,
        {                               /*yukarıda create ederken Id,Eklenme Tarihi , onaylamaları beklemesin. Aşağıda biz dolduralım.*/
            Image image = new Image();
            string[] resimler = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                var folder = Server.MapPath("~/image");    // nereye kaydedicek ? yol belirledik
                var randomfilename = Path.GetRandomFileName();    //random bir name üretsin dedik ama ilerde tekrar bir kontrol gerekebilir.. 
                //diyelim  ki şansa aynı randomu bir projede iki kez üretti.. o yüzden daha önce projede bu isimde yoksa diye kontrol gerek !   -- bir ara eklerim !
                var filename = Path.ChangeExtension(randomfilename, ".jpg");  // yukarıdaki random ismin sonuna.jpg ekledik.
                var path = Path.Combine(folder, filename);  // yol ile ismi birleştirdik.
                ViewBag.MainImageId = path;
                files[i].SaveAs(path);      // ve onları kayıt ettik.            
                resimler[i] = filename;
            }
           
            foreach (var item in resimler.Where(r => r != null))
            {
                image.ImageId = item;
                image.SessionString = Id;
                image.CreateTime = DateTime.Now;
                db.Tbl_Image.Add(image);
                db.SaveChanges();

            }

            return Json("");
        }




        [HttpPost]
        public ActionResult Resim(HttpPostedFileBase[] files, string Id ,string main, HttpPostedFileBase[] filesMain)   //HttpPostedFileBase[] files,
        {                               /*yukarıda create ederken Id,Eklenme Tarihi , onaylamaları beklemesin. Aşağıda biz dolduralım.*/
            Image image = new Image();
            if (files != null) {
                string[] resimler = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    var folder = Server.MapPath("~/image");    // nereye kaydedicek ? yol belirledik
                    var randomfilename = Path.GetRandomFileName();    //random bir name üretsin dedik ama ilerde tekrar bir kontrol gerekebilir.. 
                                                                      //diyelim  ki şansa aynı randomu bir projede iki kez üretti.. o yüzden daha önce projede bu isimde yoksa diye kontrol gerek !   -- bir ara eklerim !
                    var filename = Path.ChangeExtension(randomfilename, ".jpg");  // yukarıdaki random ismin sonuna.jpg ekledik.
                                                                                  // if (main != null && main != "") { filename = "main" + filename; }
                    var path = Path.Combine(folder, filename);  // yol ile ismi birleştirdik.
                    files[i].SaveAs(path);      // ve onları kayıt ettik.            
                    resimler[i] = filename;
                }


                foreach (var item in resimler.Where(r => r != null))
                {
                    image.ImageId = item;
                    image.SessionString = Id;
                    image.CreateTime = DateTime.Now;
                    db.Tbl_Image.Add(image);
                    db.SaveChanges();

                }
            }

            if (filesMain != null) {

                string[] anaresim = new string[filesMain.Length];
                for (int i = 0; i < filesMain.Length; i++)
                {
                    var folder = Server.MapPath("~/image");    // nereye kaydedicek ? yol belirledik
                    var randomfilename = Path.GetRandomFileName();    //random bir name üretsin dedik ama ilerde tekrar bir kontrol gerekebilir.. 
                                                                      //diyelim  ki şansa aynı randomu bir projede iki kez üretti.. o yüzden daha önce projede bu isimde yoksa diye kontrol gerek !   -- bir ara eklerim !
                    var filename = Path.ChangeExtension(randomfilename, ".jpg");  // yukarıdaki random ismin sonuna.jpg ekledik.
                    if (main != null && main != "") { filename = "mainimage" + filename; }
                    var path = Path.Combine(folder, filename);  // yol ile ismi birleştirdik.
                    filesMain[i].SaveAs(path);      // ve onları kayıt ettik.            
                    anaresim[i] = filename;
                }


                foreach (var item in anaresim.Where(r => r != null))
                {
                    image.ImageId = item;
                    image.SessionString = Id;
                    image.CreateTime = DateTime.Now;
                    db.Tbl_Image.Add(image);
                    db.SaveChanges();

                }
            }
             
            return Json("");
        }



        [HttpGet]
        public JsonResult GetCity()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<City> il = db.Tbl_City.ToList();
            ViewBag.il = il.Select(i => i.Name).ToList();
            //ViewBag.ilceler = ilce.ToList();
            return Json(il, JsonRequestBehavior.AllowGet);
            // return RedirectToAction("Create");
        }

        [HttpGet]
        public JsonResult GetDistrict (int City)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<District> ilce = db.Tbl_District.Where(i=>i.CityId==City).ToList();
            ViewBag.ilceler = ilce.Select(i=>i.Name).ToList();
            //ViewBag.ilceler = ilce.ToList();
            return Json(ilce, JsonRequestBehavior.AllowGet);
           // return RedirectToAction("Create");
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Baslik,Adres,Detaylar,StartDate,EndDate,UpdateDate,PropertyTypeId,SellingTypeId,CityId,DistrictId,RoomId,Fiyat,Boyut,Yas,KatSayisi,BuluduguKat,BanyoSayisi,BalkonSayisi,EsyaDurumu,HeatingId,AdvertTypeId,KullanimDurumu,Aidat,UserId,MapLatitude,MapLongitude,SessionString,Active")] Advert advert,string MapLatLongitude,Qualification quaa, string Side_North,string SessionRandomId)
        {
            advert.MainImage = db.Tbl_Image.Where(i => i.SessionString == SessionRandomId).Select(i => i.ImageId).FirstOrDefault();
            
            if (advert.MapLatitude == null && advert.MapLongitude == null)
            {
                string[] mapp = MapLatLongitude.Split(',');

                if(mapp[0].Trim() !="" && mapp[1].Trim() !="")
                {
                    advert.MapLatitude = mapp.Length > 0 ? mapp[0].Trim() : string.Empty;
                    advert.MapLongitude = mapp.Length > 0 ? mapp[1].Trim() : string.Empty;
                }
            }
             
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                var resimler = db.Tbl_Image.Where(a => a.SessionString == SessionRandomId).ToList();

                advert.MainImage = db.Tbl_Image.Where(i => i.SessionString == SessionRandomId).Select(i => i.ImageId).FirstOrDefault();
                advert.StartDate = DateTime.Now;
                advert.UpdateDate = DateTime.Now;
                advert.AdvertTypeId = 1;
                advert.Active = false;
                advert.UserId =Convert.ToInt32(Session["UserID"]);
                //buraya enddate e 20 gün deriz ama if premium==true ise 60 gün vs diyebiliriz.
                advert.EndDate = DateTime.Now.AddDays(20);
                db.Tbl_Advert.Add(advert);
                 
                db.SaveChanges();

                //quaa = new Qualification();
                //Qualification Qualific = new Qualification();
                quaa.AdvertId = advert.ID;
                quaa.CreateTime = DateTime.Now;
                quaa.SessionString = SessionRandomId;
               // advert.ID = Qualific.AdvertId;  //oluşturulan ilanın ID si özellikler tablosuna eklendi.
                #region kapalı checkbox için dokunma
                //if (qual.BathroomType_Alafranga == "on") { Qualific.BathroomType_Alafranga = true; } else { Qualific.BathroomType_Alafranga = false; }
                //if (qual.Side_North == "on") { Qualific.Side_North = true; } else { Qualific.Side_North = false; }
                //if (qual.Side_South == "on") { Qualific.Side_South = true; } else { Qualific.Side_South = false; }
                //if (qual.Side_West == "on") { Qualific.Side_West = true; } else { Qualific.Side_West = false; }
                //if (qual.Side_East == "on") { Qualific.Side_East = true; } else { Qualific.Side_East = false; }
                //if (qual.RoomType_TV == "on") { Qualific.RoomType_TV = true; } else { Qualific.RoomType_TV = false; }
                //if (qual.RoomType_Tel == "on") { Qualific.RoomType_Tel = true; } else { Qualific.RoomType_Tel = false; }
                //if (qual.RoomType_MoneyCase == "on") { Qualific.RoomType_MoneyCase = true; } else { Qualific.RoomType_MoneyCase = false; }
                //if (qual.RoomType_Closet == "on") { Qualific.RoomType_Closet = true; } else { Qualific.RoomType_Closet = false; }
                //if (qual.RoomType_WashingMachine == "on") { Qualific.RoomType_WashingMachine = true; } else { Qualific.RoomType_WashingMachine = false; }
                //if (qual.RoomType_DishWasher == "on") { Qualific.RoomType_DishWasher = true; } else { Qualific.RoomType_DishWasher = false; }
                //if (qual.RoomType_LaundryRoom == "on") { Qualific.RoomType_LaundryRoom = true; } else { Qualific.RoomType_LaundryRoom = false; }
                //if (qual.RoomType_AirConditioner == "on") { Qualific.RoomType_AirConditioner = true; } else { Qualific.RoomType_AirConditioner = false; }
                //if (qual.RoomType_Cellar == "on") { Qualific.RoomType_Cellar = true; } else { Qualific.RoomType_Cellar = false; }
                //if (qual.RoomType_Balcony == "on") { Qualific.RoomType_Balcony = true; } else { Qualific.RoomType_Balcony = false; }
                //if (qual.RoomType_Terrace == "on") { Qualific.RoomType_Terrace = true; } else { Qualific.RoomType_Terrace = false; }
                //if (qual.RoomType_Barbeque == "on") { Qualific.RoomType_Barbeque = true; } else { Qualific.RoomType_Barbeque = false; }
                //if (qual.RoomType_WhiteAppliances == "on") { Qualific.RoomType_WhiteAppliances = true; } else { Qualific.RoomType_WhiteAppliances = false; }
                //if (qual.RoomType_Refrigerator == "on") { Qualific.RoomType_Refrigerator = true; } else { Qualific.RoomType_Refrigerator = false; }
                //if (qual.RoomType_ParentBath == "on") { Qualific.RoomType_ParentBath = true; } else { Qualific.RoomType_ParentBath = false; }
                //if (qual.RoomType_Kartonpiyer == "on") { Qualific.RoomType_Kartonpiyer = true; } else { Qualific.RoomType_Kartonpiyer = false; }
                //if (qual.RoomType_Ankastre == "on") { Qualific.RoomType_Ankastre = true; } else { Qualific.RoomType_Ankastre = false; }
                //if (qual.RoomType_Laminant == "on") { Qualific.RoomType_Laminant = true; } else { Qualific.RoomType_Laminant = false; }
                //if (qual.RoomType_Panjur == "on") { Qualific.RoomType_Panjur = true; } else { Qualific.RoomType_Panjur = false; }
                //if (qual.RoomType_Furniture == "on") { Qualific.RoomType_Furniture = true; } else { Qualific.RoomType_Furniture = false; }
                //if (qual.RoomType_SteelDoor == "on") { Qualific.RoomType_SteelDoor = true; } else { Qualific.RoomType_SteelDoor = false; }
                //if (qual.RoomType_Thermopane == "on") { Qualific.RoomType_Thermopane = true; } else { Qualific.RoomType_Thermopane = false; }
                //if (qual.RoomType_SeramikGround == "on") { Qualific.RoomType_SeramikGround = true; } else { Qualific.RoomType_SeramikGround = false; }
                //if (qual.RoomType_ParkeGround == "on") { Qualific.RoomType_ParkeGround = true; } else { Qualific.RoomType_ParkeGround = false; }
                //if (qual.RoomType_FirePlace == "on") { Qualific.RoomType_FirePlace = true; } else { Qualific.RoomType_FirePlace = false; }
                //if (qual.BathroomType_Tub == "on") { Qualific.BathroomType_Tub = true; } else { Qualific.BathroomType_Tub = false; }
                //if (qual.BathroomType_Jacuzzi == "on") { Qualific.BathroomType_Jacuzzi = true; } else { Qualific.BathroomType_Jacuzzi = false; }
                //if (qual.BathroomType_Cabin == "on") { Qualific.BathroomType_Cabin = true; } else { Qualific.BathroomType_Cabin = false; }
                //if (qual.BathroomType_Alaturka == "on") { Qualific.BathroomType_Alaturka = true; } else { Qualific.BathroomType_Alaturka = false; }
                //if (qual.BathroomType_Alafranga == "on") { Qualific.BathroomType_Alafranga = true; } else { Qualific.BathroomType_Alafranga = false; }
                //if (qual.ViewType_Mountain == "on") { Qualific.ViewType_Mountain = true; } else { Qualific.ViewType_Mountain = false; }
                //if (qual.ViewType_Sea == "on") { Qualific.ViewType_Sea = true; } else { Qualific.ViewType_Sea = false; }
                //if (qual.ViewType_Bosphorus == "on") { Qualific.ViewType_Bosphorus = true; } else { Qualific.ViewType_Bosphorus = false; }
                //if (qual.ViewType_Forest == "on") { Qualific.ViewType_Forest = true; } else { Qualific.ViewType_Forest = false; }
                //if (qual.ViewType_City == "on") { Qualific.ViewType_City = true; } else { Qualific.ViewType_City = false; }
                //if (qual.ViewType_Historical == "on") { Qualific.ViewType_Historical = true; } else { Qualific.ViewType_Historical = false; }
                //if (qual.GroundType_ADSL == "on") { Qualific.GroundType_ADSL = true; } else { Qualific.GroundType_ADSL = false; }
                //if (qual.GroundType_Fiber == "on") { Qualific.GroundType_Fiber = true; } else { Qualific.GroundType_Fiber = false; }
                //if (qual.GroundType_Wifi == "on") { Qualific.GroundType_Wifi = true; } else { Qualific.GroundType_Wifi = false; }
                //if (qual.GroundType_CableTV == "on") { Qualific.GroundType_CableTV = true; } else { Qualific.GroundType_CableTV = false; }
                //if (qual.Environment_PreSchool == "on") { Qualific.Environment_PreSchool = true; } else { Qualific.Environment_PreSchool = false; }
                //if (qual.Environment_MidSchool == "on") { Qualific.Environment_MidSchool = true; } else { Qualific.Environment_MidSchool = false; }
                //if (qual.Environment_University == "on") { Qualific.Environment_University = true; } else { Qualific.Environment_University = false; }
                //if (qual.Environment_Hospital == "on") { Qualific.Environment_Hospital = true; } else { Qualific.Environment_Hospital = false; }
                //if (qual.Environment_Mosque == "on") { Qualific.Environment_Mosque = true; } else { Qualific.Environment_Mosque = false; }
                //if (qual.Environment_Avm == "on") { Qualific.Environment_Avm = true; } else { Qualific.Environment_Avm = false; }
                //if (qual.Environment_Municipality == "on") { Qualific.Environment_Municipality = true; } else { Qualific.Environment_Municipality = false; }
                //if (qual.Environment_Market == "on") { Qualific.Environment_Market = true; } else { Qualific.Environment_Market = false; }
                //if (qual.Environment_FunLand == "on") { Qualific.Environment_FunLand = true; } else { Qualific.Environment_FunLand = false; }
                //if (qual.Environment_Police == "on") { Qualific.Environment_Police = true; } else { Qualific.Environment_Police = false; }
                //if (qual.Environment_Park == "on") { Qualific.Environment_Park = true; } else { Qualific.Environment_Park = false; }
                //if (qual.Transport_Bus == "on") { Qualific.Transport_Bus = true; } else { Qualific.Transport_Bus = false; }
                //if (qual.Transport_Minibus == "on") { Qualific.Transport_Minibus = true; } else { Qualific.Transport_Minibus = false; }
                //if (qual.Transport_Subway == "on") { Qualific.Transport_Subway = true; } else { Qualific.Transport_Subway = false; }
                //if (qual.Transport_Tem == "on") { Qualific.Transport_Tem = true; } else { Qualific.Transport_Tem = false; }
                //if (qual.Transport_E5 == "on") { Qualific.Transport_E5 = true; } else { Qualific.Transport_E5 = false; }
                //if (qual.Transport_Metrobus == "on") { Qualific.Transport_Metrobus = true; } else { Qualific.Transport_Metrobus = false; }
                //if (qual.Transport_Teleferik == "on") { Qualific.Transport_Teleferik = true; } else { Qualific.Transport_Teleferik = false; }
                //if (qual.Transport_Tramvay == "on") { Qualific.Transport_Tramvay = true; } else { Qualific.Transport_Tramvay = false; }
                //if (qual.Transport_Pier == "on") { Qualific.Transport_Pier = true; } else { Qualific.Transport_Pier = false; }
                //if (qual.Transport_Airport == "on") { Qualific.Transport_Airport = true; } else { Qualific.Transport_Airport = false; }
                //if (qual.HousingType_Arakat == "on") { Qualific.HousingType_Arakat = true; } else { Qualific.HousingType_Arakat = false; }
                //if (qual.HousingType_Bahceli == "on") { Qualific.HousingType_Bahceli = true; } else { Qualific.HousingType_Bahceli = false; }
                //if (qual.HousingType_Bahcekati == "on") { Qualific.HousingType_Bahcekati = true; } else { Qualific.HousingType_Bahcekati = false; }
                //if (qual.HousingType_TersDublex == "on") { Qualific.HousingType_TersDublex = true; } else { Qualific.HousingType_TersDublex = false; }
                //if (qual.HousingType_Arakatdublex == "on") { Qualific.HousingType_Arakatdublex = true; } else { Qualific.HousingType_Arakatdublex = false; }
                //if (qual.HousingType_Enustkat == "on") { Qualific.HousingType_Enustkat = true; } else { Qualific.HousingType_Enustkat = false; }
                //if (qual.HousingType_Triplex == "on") { Qualific.HousingType_Triplex = true; } else { Qualific.HousingType_Triplex = false; }
                //if (qual.HousingType_Bahcedublex == "on") { Qualific.HousingType_Bahcedublex = true; } else { Qualific.HousingType_Bahcedublex = false; }
                //if (qual.HousingType_Catidublex == "on") { Qualific.HousingType_Catidublex = true; } else { Qualific.HousingType_Catidublex = false; }
                //if (qual.HousingType_Mustakil == "on") { Qualific.HousingType_Mustakil = true; } else { Qualific.HousingType_Mustakil = false; }
                #endregion kapalı
               // Qualific.CreateTime = DateTime.Now;
               // Qualific.SessionString = SessionRandomId;
                db.Tbl_Qualification.Add(quaa);

                foreach (var item in resimler)
                {
                    item.AdvertId = advert.ID;
                }

                db.SaveChanges();

                return RedirectToAction("Index","Home",new { newadvertid=advert.ID});
            }
             
            ViewBag.PropertyTypeId = new SelectList(db.Tbl_PropertyType, "ID", "Ad", advert.PropertyTypeId);
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name", advert.CityId);
            ViewBag.AdvertTypeId = new SelectList(db.Tbl_AdvertType, "ID", "ID", advert.AdvertTypeId);
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name", advert.DistrictId);
            ViewBag.HeatingId = new SelectList(db.Tbl_Heating, "ID", "Ad", advert.HeatingId);
            ViewBag.RoomId = new SelectList(db.Tbl_Room, "ID", "Ad", advert.RoomId);
            ViewBag.SellingTypeId = new SelectList(db.Tbl_SellingType, "ID", "Ad", advert.SellingTypeId);
            ViewBag.UserId = new SelectList(db.Tbl_User, "ID", "Ad", advert.UserId);

            ViewBag.createfailure = "İlan Oluşturulamadı";
            return View(advert);
        }

        // GET: Advert/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advert advert = db.Tbl_Advert.Find(id);
            if (advert == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyTypeId = new SelectList(db.Tbl_PropertyType, "ID", "Ad", advert.PropertyTypeId);
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name", advert.CityId);
            ViewBag.AdvertTypeId = new SelectList(db.Tbl_AdvertType, "ID", "ID", advert.AdvertTypeId);
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name", advert.DistrictId);
            ViewBag.HeatingId = new SelectList(db.Tbl_Heating, "ID", "Ad", advert.HeatingId);
            ViewBag.RoomId = new SelectList(db.Tbl_Room, "ID", "Ad", advert.RoomId);
            ViewBag.SellingTypeId = new SelectList(db.Tbl_SellingType, "ID", "Ad", advert.SellingTypeId);
            ViewBag.UserId = new SelectList(db.Tbl_User, "ID", "Ad", advert.UserId);
            return View(advert);
        }

        // POST: Advert/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Baslik,Adres,Detaylar,StartDate,EndDate,UpdateDate,PropertyTypeId,SellingTypeId,CityId,DistrictId,RoomId,Fiyat,Boyut,Yas,KatSayisi,BuluduguKat,BanyoSayisi,BalkonSayisi,EsyaDurumu,HeatingId,AdvertTypeId,KullanimDurumu,Aidat,UserId,SessionString,Active")] Advert advert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyTypeId = new SelectList(db.Tbl_PropertyType, "ID", "Ad", advert.PropertyTypeId);
            ViewBag.CityId = new SelectList(db.Tbl_City, "ID", "Name", advert.CityId);
            ViewBag.AdvertTypeId = new SelectList(db.Tbl_AdvertType, "ID", "ID", advert.AdvertTypeId);
            ViewBag.DistrictId = new SelectList(db.Tbl_District, "ID", "Name", advert.DistrictId);
            ViewBag.HeatingId = new SelectList(db.Tbl_Heating, "ID", "Ad", advert.HeatingId);
            ViewBag.RoomId = new SelectList(db.Tbl_Room, "ID", "Ad", advert.RoomId);
            ViewBag.SellingTypeId = new SelectList(db.Tbl_SellingType, "ID", "Ad", advert.SellingTypeId);
            ViewBag.UserId = new SelectList(db.Tbl_User, "ID", "Ad", advert.UserId);
            return View(advert);
        }

        // GET: Advert/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advert advert = db.Tbl_Advert.Find(id);
            if (advert == null)
            {
                return HttpNotFound();
            }
            return View(advert);
        }

        // POST: Advert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advert advert = db.Tbl_Advert.Find(id);
            db.Tbl_Advert.Remove(advert);
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
        public ActionResult Map()
        {
            return View();
        }
    }
}
