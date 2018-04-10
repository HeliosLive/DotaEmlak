using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Adınız")]
        public string Ad { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Soyad { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        [EmailAddress(ErrorMessage = "E-Mail adresini hatalı girdiniz.")]
        public string EMail { get; set; }

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

        [ForeignKey("Rol")]  // apartman,villa,plaza,arazi vsvs...
        [DisplayName("Kullanıcı Rolü")]
        public int RoleId { get; set; }
        public UserRole Rol { get; set; }

        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastOnline { get; set; }
        public bool Active { get; set; }
    }
}

 