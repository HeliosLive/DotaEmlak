using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        [EmailAddress(ErrorMessage = "E-Mail adresini hatalı girdiniz.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Tel No")] 
        public string TelNo { get; set; }

        [Required]
        [DisplayName("Şifre")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [PasswordPropertyText]
        [Compare("Password", ErrorMessage = "Şifreleriniz Uyuşmuyor..")]
        public string RePassword { get; set; }

    }
}