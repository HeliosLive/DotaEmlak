using EmlakProjesi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace EmlakProjesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        //var sql = db.Database.ExecuteSqlCommand("");
        //var bll = db.Database.SqlQuery<string>("").ToList();


        private AdvertContext context = new AdvertContext();
        public ActionResult Index(int? newadvertid, int? sira,int ? page)
        {
            if (sira != null)
            {
                ViewBag.newadvertid = newadvertid;

                ViewBag.sira = sira;
                ViewData["_PCityId"] = context.Tbl_City.ToList();
                ViewData["_PRoomId"] = context.Tbl_Room.ToList();
                ViewData["_PSellingTypeId"] = context.Tbl_SellingType.ToList();
                ViewData["_PHeatingTypeId"] = context.Tbl_Heating.ToList();

                var ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
                 Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
                 Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
                 .Where(i => i.Active == true && i.IsSold == false);


                switch (sira)
                {
                    case 1:
                        ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
              Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
              Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
              .Where(i => i.Active == true && i.IsSold == false).OrderByDescending(i => i.StartDate); break;

                    case 2:
                        ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
          Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
          Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
          .Where(i => i.Active == true && i.IsSold == false).OrderBy(i => i.StartDate); break;
                    case 3:
                        ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
          Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
          Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
          .Where(i => i.Active == true && i.IsSold == false).OrderByDescending(i => i.Fiyat); break;
                    case 4:
                        ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
          Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
          Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
          .Where(i => i.Active == true && i.IsSold == false).OrderBy(i => i.Fiyat); break;
                }

                //.OrderByDescending(i => i.StartDate);

                ViewBag.ilansayisi = ilanlar.Count();
                ViewData["ilanlar"] = ilanlar.ToList().ToPagedList(page ?? 1,3);
            }
            else
            {
                ViewBag.newadvertid = newadvertid;

                ViewBag.sira = 0;

                ViewData["_PCityId"] = context.Tbl_City.ToList();
                ViewData["_PRoomId"] = context.Tbl_Room.ToList();
                ViewData["_PSellingTypeId"] = context.Tbl_SellingType.ToList();
                ViewData["_PHeatingTypeId"] = context.Tbl_Heating.ToList();

                var ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
                 Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
                 Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
                 .Where(i => i.Active == true && i.IsSold==false)
                 .OrderByDescending(i => i.StartDate);

                ViewBag.ilansayisi = ilanlar.Count();
                ViewData["ilanlar"] = ilanlar.ToList().ToPagedList(page ?? 1, 3);
            }

            //WeatherService.GlobalWeatherSoapClient client = new WeatherService.GlobalWeatherSoapClient();
            //var a = client.GetCitiesByCountry("Turkey");

            //calculatorservice.CalculatorSoapClient calculate = new calculatorservice.CalculatorSoapClient();
            //var aa = 20;
            //var bb = 30;
            //var cc = 40; 

            //var dd=calculate.Add(aa,bb);
            //var ee = calculate.Divide(cc,bb);
            //var havadurumu=client.GetWeather("","Turkey");

            return View();
        }

 

        [HttpPost]
        public ActionResult Index(SmartSearch arama, int? newadvertid, int? Id,int ? page)
        {
            ViewBag.newadvertid = newadvertid;


            ViewData["_PCityId"] = context.Tbl_City.ToList();
            ViewData["_PRoomId"] = context.Tbl_Room.ToList();
            ViewData["_PSellingTypeId"] = context.Tbl_SellingType.ToList();
            ViewData["_PHeatingTypeId"] = context.Tbl_Heating.ToList();

            if (arama.HeatingId == null) { arama.HeatingId = context.Tbl_Heating.Select(i => i.ID).ToList(); }
            // if (arama.DistrictId==null) { arama.DistrictId = context.Tbl_District.Select(i => i.ID).ToList(); }
            if (arama.RoomId == null) { arama.RoomId = context.Tbl_Room.Select(i => i.ID).ToList(); }
            if (arama.SellingTypeId == null) { arama.SellingTypeId = context.Tbl_SellingType.Select(i => i.ID).ToList(); }
            if (arama.city.Count == 1 && arama.city.First() == 0) { arama.city = context.Tbl_City.Select(i => i.ID).ToList(); }
            if (arama.DistrictId==null)
            {
                if (arama.city.Count == 1 && arama.city.First() == 0)
                {
                    arama.DistrictId = context.Tbl_District.Select(i => i.ID).ToList();
                }
                else
                {
                    arama.DistrictId = context.Tbl_District.Where(i => arama.city.Contains(i.CityId)).Select(i => i.ID).ToList();
                }
               
            }
            if (arama.title == null) { arama.title = ""; }

            int maxmetre = Convert.ToInt32(arama.maxmetre); int minmetre = Convert.ToInt32(arama.minmetre);
            int maxfiyat = Convert.ToInt32(arama.maxfiyat); int minfiyat = Convert.ToInt32(arama.minfiyat);
            //int city = Convert.ToInt32(arama.city); int district = Convert.ToInt32(arama.DistrictId);

            var ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
             Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
             Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi).Where(i => i.Baslik.Contains(arama.title)
                 && i.Boyut < maxmetre && i.Boyut > minmetre
                 && arama.city.Contains(i.CityId) && arama.DistrictId.Contains(i.DistrictId)
                 // && i.CityId == city && i.DistrictId == district
                 && arama.RoomId.Contains(i.RoomId) && arama.HeatingId.Contains(i.HeatingId)
                 && arama.SellingTypeId.Contains(i.SellingTypeId)
                ).Where( i=>i.IsSold == false).ToList();

            ViewBag.ilansayisi = ilanlar.Count();
            ViewData["ilanlar"] = ilanlar.ToList().ToPagedList(page ?? 1, 9);

            return View();

        }

        public ActionResult List()
        {
            var ilanlar = context.Tbl_Advert.Include(b => b.isitmatipi).Include(b => b.il).
                Include(b => b.ilce).Include(b => b.EmlakTipi).Include(b => b.kacoda).
                Include(b => b.SatisTipi).Include(b => b.User).Include(b => b.ilantipi)
                .Where(i => i.Active == true).OrderByDescending(i => i.StartDate);

            return View(ilanlar.ToList());
        }

        [HttpPost]
        public JsonResult SendMailToUser(string EmailToWho,string title,string body)
        {
            bool result = false;
            result = SendMail(EmailToWho,"Yeni Haberlere Üye Oldunuz."," Merhaba, <br/> Dota Emlak'a hoşgeldiniz. <p> Yeni girilen ilanlardan sizleri haberdar edeceğiz. <p/> <br/> İyi Günler Dileriz.");
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public bool SendMail(string toEmail,string subject,string emailbody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                var client = new SmtpClient("smtp.gmail.com",587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail,senderPassword);

                MailMessage mailmessage = new MailMessage(senderEmail,toEmail,subject,emailbody);
                mailmessage.IsBodyHtml = true;
                mailmessage.BodyEncoding=UTF8Encoding.UTF8;
                client.Send(mailmessage);
                
                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }

    }
     
}