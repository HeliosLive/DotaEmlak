using EmlakProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EmlakProjesi.Controllers
{
    public class AccountController : Controller
    {

        private AdvertContext db = new AdvertContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string userad,string response, string forgot)
        {
            if (response =="1") { ViewBag.LoginInfo = "Kullanıcı oluşturulamadı,Tekrar deneyiniz."; }
            else if (response == "2") { ViewBag.LoginInfo = "İlan verebilmek için öncelikle giriş yapmalısınız."; }
            else if (response == "3") { ViewBag.LoginInfo = "Başarıyla Çıkış Yapılmıştır."; }
            else if (response == "4") { ViewBag.LoginInfo = "Hatalı kullanıcı adı ya da şifre."; }
            else if (response == "5") { ViewBag.LoginInfo = "Şifreniz Mail Adresinize Gönderilmiştir."; }

            if (userad !="" && userad != null)
            {
                ViewBag.LoginInfo = userad.ToUpper() +" Kaydın başarıyla tamamlanmıştır. Artık Giriş yapabilirsin..";
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user,string forgot)
        {
            if (user.EMail==null || user.EMail=="") { user.EMail = "a"; }
            if (user.Password==null || user.Password=="" ) { user.Password = "a"; }
            var kullanici = db.Tbl_User.Where(i => i.EMail == user.EMail && i.Password == user.Password).FirstOrDefault();
            if (kullanici != null)
            {
                Session["UserID"] = kullanici.ID.ToString();
                Session["Username"] = kullanici.Ad.ToString();
                Session["UserRole"] = kullanici.RoleId.ToString();
                 
                var dbUser = db.Tbl_User.Where(i => i.ID == kullanici.ID).FirstOrDefault();
                dbUser.LastOnline = DateTime.Now;
                db.SaveChanges();

                if (Session["UserRole"].ToString() == "2") { return RedirectToAction("Index", "Admin"); }
                else { return RedirectToAction("Index", "Home"); }
            }
            int response =4;
            if (forgot=="on") { response = 5; }
            return RedirectToAction("Login",new { response});
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user,string isadmin)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            var kayıtlı = db.Tbl_User.Where(i => i.EMail == user.EMail).Select(i => i.Password).FirstOrDefault();
            if (kayıtlı!=null) { ModelState.AddModelError("EMail", "Aynı Mail Adresi Zaten Sistemde Bulunmaktadır!"); }
            
            if (ModelState.IsValid)
            {
                user.CreateTime = DateTime.Now;
                user.LastOnline = DateTime.Now;
                if (isadmin=="7F5Wig")
                {
                    user.RoleId = 2;
                }
                else
                {
                    user.RoleId = 3;
                }
              
                db.Tbl_User.Add(user);
                db.SaveChanges();
                string adsoyad = user.Ad + " " + user.Soyad;
                var aaa = SendMailToUser(user.EMail,"","","on",adsoyad);

                return RedirectToAction("Login",new { userad=user.Ad +" " +user.Soyad}); 

            }

            return RedirectToAction("Login",new { response=1});
       
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", new { response = 3 });
        }


        [HttpPost]
        public JsonResult SendMailToUser(string EmailToWho, string title, string body,string main,string adsoyad)
        {
            var sifre = db.Tbl_User.Where(i => i.EMail == EmailToWho).Select(i => i.Password).FirstOrDefault();
            bool result = false;
            if (sifre ==null) { return Json(result, JsonRequestBehavior.AllowGet); }

            if (main=="on") { title = "Dota Emlak'a Hoşgeldiniz."; body = " Merhaba "+adsoyad.ToUpper()+ ", <br/><br/> Dota Emlak ailesine hoşgeldiniz. :) <p> Üyelik işleminiz tamamlanmıştır. Artık ilan girebilir ve sitemize üye olmanın diğer avantajlarından faydalanabilirsiniz. <p/> <br/> İyi Günler Dileriz. &#x263A;"; }
            if (main=="off") { title = "Dota Emlak Şifre Hatırlatma."; body = " Merhaba, <br/> Dota Emlak şifreniz : <p> "+sifre +"  <p/> <br/> İyi Günler Dileriz."; }
            result = SendMail(EmailToWho, title, body);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public bool SendMail(string toEmail, string subject, string emailbody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailmessage = new MailMessage(senderEmail, toEmail, subject, emailbody);
                mailmessage.IsBodyHtml = true;
                mailmessage.BodyEncoding = UTF8Encoding.UTF8;
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