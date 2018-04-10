using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class Advert
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Resim")] 
        public string MainImage { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "Başlık Zorunludur!")]
        public string Baslik { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres Zorunludur!")]
        public string Adres { get; set; }

        [DisplayName("Detaylar")]
        [Required(ErrorMessage = "Detaylar Zorunludur!")]
        public string Detaylar { get; set; }

        [DisplayName("Başlangıç Tarihi")] 
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [DisplayName("Son Güncelleme")]
        public DateTime UpdateDate { get; set; }

        [ForeignKey("EmlakTipi")]  // apartman,villa,plaza,arazi vsvs...
        [DisplayName("Emlak Tipi")]
        public int PropertyTypeId { get; set; }
        public PropertyType EmlakTipi { get; set; }

        [ForeignKey("SatisTipi")]  // günlük kiralık,kiralık,satılık,..
        [DisplayName("Satış Tipi")]
        public int SellingTypeId { get; set; }
        public SellingType SatisTipi { get; set; }

        [ForeignKey("il")]
        [DisplayName("İl")]
        public int CityId { get; set; }
        public City il { get; set; }

        [ForeignKey("ilce")]
        [DisplayName("İlçe")]
        public int DistrictId { get; set; }
        public District ilce { get; set; }

        [ForeignKey("kacoda")]
        [DisplayName("Oda Sayısı")]
        public int RoomId { get; set; }
        public Room kacoda { get; set; }

        public float Fiyat { get; set; }

        [DisplayName("m2")]
        [Required(ErrorMessage = "Ev Boyutu Zorunludur!")]
        public int Boyut { get; set; }  //metre kare cinsinden

        [DisplayName("Bina Yaşı")]
        [Required(ErrorMessage = "Bina Yaşı Zorunludur!")]
        public int Yas { get; set; }

        [DisplayName("Kat Sayısı")]
        [Required(ErrorMessage = "Kat Sayısı Zorunludur!")]
        public int KatSayisi { get; set; }

        [DisplayName("Bulunduğu Kat")]
        [Required(ErrorMessage = "Bulunan Kat Zorunludur!")]
        public int BuluduguKat { get; set; }

        [DisplayName("Banyo Sayısı")]
        [Required(ErrorMessage = "Banyo Sayısı Zorunludur!")]
        public int BanyoSayisi { get; set; }

        [DisplayName("Balkon Sayısı")]
        [Required(ErrorMessage = "Balkon Sayısı Zorunludur!")]
        public int BalkonSayisi { get; set; }

        [DisplayName("Eşyalı")]
        public bool EsyaDurumu { get; set; }

        [ForeignKey("isitmatipi")]
        [DisplayName("Isıtma")]
        public int HeatingId { get; set; }
        public Heating isitmatipi { get; set; }

        //[ForeignKey("resimler")]
        //public List<string> ImageId { get; set; }
        //public virtual Image resimler { get; set; }

        //[ForeignKey("özellikler")]
        //public List<string> QualifcationId { get; set; }
        //public virtual Qualification özellikler { get; set; }

        [ForeignKey("ilantipi")]
        public int AdvertTypeId { get; set; }
        public AdvertType ilantipi { get; set; }

        [DisplayName("Kullanım Durumu")]
        public bool KullanimDurumu { get; set; }   //kiracı var mı yok mu?

        [DisplayName("Aidat")]
        public float Aidat { get; set; }


        [ForeignKey("User")]
        [DisplayName("İlan Sahibi")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string MapLatitude { get; set; }
        public string MapLongitude { get; set; }
        public string SessionString { get; set; } 
        public int ViewCounter { get; set; }
        public bool Active { get; set; }
        public bool IsSold { get; set; }

    }
}