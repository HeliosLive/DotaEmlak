using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class Qualification
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Kuzey")]
        public bool Side_North { get; set; }  //kuzey cephesi

        [DisplayName("Güney")]
        public bool Side_South { get; set; }  //güney cephesi

        [DisplayName("Batı")]
        public bool Side_West { get; set; }  //batı cephesi

        [DisplayName("Doğu")]
        public bool Side_East { get; set; }  //doğu cephesi

        [DisplayName("TV")]
        public bool RoomType_TV { get; set; }   //televizyon

        [DisplayName("Ankesör Telefon")]
        public bool RoomType_Tel { get; set; }  //telefon 

        [DisplayName("Para Kasası")]
        public bool RoomType_MoneyCase { get; set; }   //parakasası

        [DisplayName("Gömme Dolap")]
        public bool RoomType_Closet { get; set; }  //dolap

        [DisplayName("Çamaşır Makinesi")]
        public bool RoomType_WashingMachine { get; set; }  //çamaşır makinesi

        [DisplayName("Bulaşık Makinesi")]
        public bool RoomType_DishWasher { get; set; }  //bulaşık makinesi

        [DisplayName("Çamaşır Odası")]
        public bool RoomType_LaundryRoom { get; set; }  //çamaşır odası

        [DisplayName("Klima")]
        public bool RoomType_AirConditioner { get; set; }  //airconditior klima

        [DisplayName("Kiler")]
        public bool RoomType_Cellar { get; set; }   //Kiler 

        [DisplayName("Balkon")]
        public bool RoomType_Balcony { get; set; }  //balkon

        [DisplayName("Teras")]
        public bool RoomType_Terrace { get; set; }  //teras

        [DisplayName("Barbekü")]
        public bool RoomType_Barbeque  { get; set; }  //barbekü

        [DisplayName("Beyaz Eşya")]
        public bool RoomType_WhiteAppliances { get; set; }   //beyaz eşya

        [DisplayName("Buzdolabı")]
        public bool RoomType_Refrigerator { get; set; }  //Buzdolabı

        [DisplayName("Ebeveyn Banyosu")]
        public bool RoomType_ParentBath { get; set; }   //Ebeveyn Banyosu

        [DisplayName("Kartonpiyer")]
        public bool RoomType_Kartonpiyer { get; set; }  //Kartonpiyer

        [DisplayName("Ankastre")]
        public bool RoomType_Ankastre { get; set; }    //Ankastre

        [DisplayName("Laminant Zemin")]
        public bool RoomType_Laminant { get; set; }   //laminant zemin

        [DisplayName("Panjur")]
        public bool RoomType_Panjur { get; set; }  //Panjur

        [DisplayName("Mobilya")]
        public bool RoomType_Furniture { get; set; }  //Mobilya 

        [DisplayName("Çelik  Kapı")]
        public bool RoomType_SteelDoor { get; set; }   //çelik kapı

        [DisplayName("Isıcam")]
        public bool RoomType_Thermopane { get; set; }  //ısıcam

        [DisplayName("Seramik Zemin")]
        public bool RoomType_SeramikGround { get; set; }   //seramik zemin

        [DisplayName("Parke Zemins")]
        public bool RoomType_ParkeGround { get; set; }      //parke zemin

        [DisplayName("Şömine")]
        public bool RoomType_FirePlace { get; set; }   //şömine

        [DisplayName("Küvet")]
        public bool BathroomType_Tub { get; set; }  //küvet

        [DisplayName("Jakuzi")]
        public bool BathroomType_Jacuzzi { get; set; } //jakuzi

        [DisplayName("Duşakabin")]
        public bool BathroomType_Cabin { get; set; }  //duşakabin

        [DisplayName("Alaturka Tuvalet")]
        public bool BathroomType_Alaturka { get; set; }  //tuvalet tipi

        [DisplayName("Alafranga Tuvalet")]
        public bool BathroomType_Alafranga { get; set; }  //tuvalet tipi

        [DisplayName("Dağ")]
        public bool ViewType_Mountain { get; set; }  //MANZARA _ dağ

        [DisplayName("Deniz")]
        public bool ViewType_Sea { get; set; }      //deniz

        [DisplayName("Boğaz")]
        public bool ViewType_Bosphorus { get; set; }      //boğaz 

        [DisplayName("Orman")]
        public bool ViewType_Forest { get; set; }    //orman

        [DisplayName("Şehir")]
        public bool ViewType_City { get; set; }     //şehir

        [DisplayName("Tarihi")]
        public bool ViewType_Historical { get; set; }  //tarihi

        [DisplayName("ADSL")]
        public bool GroundType_ADSL { get; set; }   // ALTYAPI _adsl internet

        [DisplayName("Fiber")]
        public bool GroundType_Fiber { get; set; }  //fiber internet

        [DisplayName("Wifi")]
        public bool GroundType_Wifi { get; set; }   //wifi mesela sitelerde otomatik wifi

        [DisplayName("Kablolu TV")]
        public bool GroundType_CableTV { get; set; }  //kablolu TV

        [DisplayName("İlkokul")]
        public bool Environment_PreSchool { get; set; }    //ÇEVRE _ilkokul

        [DisplayName("Ortaokul")]
        public bool Environment_MidSchool { get; set; }    //ortaokul

        [DisplayName("Üniversite")]
        public bool Environment_University { get; set; }    //üniversite

        [DisplayName("Hastane")]
        public bool Environment_Hospital { get; set; }      //hastane

        [DisplayName("Camii")]
        public bool Environment_Mosque { get; set; }        //camii

        [DisplayName("Avm")]
        public bool Environment_Avm { get; set; }       //alışveriş merkezi

        [DisplayName("Belediye")]
        public bool Environment_Municipality { get; set; }          //belediye

        [DisplayName("Market")]
        public bool Environment_Market { get; set; }        //market

        [DisplayName("Eğlence Merkezi")]
        public bool Environment_FunLand { get; set; }       //eğlence merkezi

        [DisplayName("Karakol")]
        public bool Environment_Police { get; set; }        //karakol

        [DisplayName("Oyun Parkı")]
        public bool Environment_Park { get; set; }      //park yeri var mı çevrede

        [DisplayName("Otobüs")]
        public bool Transport_Bus { get; set; }     //ULAŞIM _ otobüs

        [DisplayName("Minibüs")]
        public bool Transport_Minibus { get; set; }     //minibüs

        [DisplayName("Metro")]
        public bool Transport_Subway { get; set; }      //metro

        [DisplayName("Tem")]
        public bool Transport_Tem { get; set; }     //tem yolu

        [DisplayName("E5")]
        public bool Transport_E5 { get; set; }      //E5

        [DisplayName("Metrobüs")]
        public bool Transport_Metrobus { get; set; }        //metrobüs

        [DisplayName("Teleferik")]
        public bool Transport_Teleferik { get; set; }       //teleferik

        [DisplayName("Tramvay")]
        public bool Transport_Tramvay { get; set; } //tramvay

        [DisplayName("İskele")]
        public bool Transport_Pier { get; set; }  //iskele

        [DisplayName("Hava Alanı")]
        public bool Transport_Airport { get; set; }  //havaalanı

        [DisplayName("Arakat")]
        public bool HousingType_Arakat { get; set; }  // KONUT tipleri türkçe bu kısım_ arakat daire

        [DisplayName("Bahçeli Binada")]
        public bool HousingType_Bahceli { get; set; }   //bahçe kat

        [DisplayName("Bahçe Katı")]
        public bool HousingType_Bahcekati { get; set; }     //bahçe katı    

        [DisplayName("Ters Dubleks")]
        public bool HousingType_TersDublex { get; set; }        //ters dubleks

        [DisplayName("Ara Dubleks")]
        public bool HousingType_Arakatdublex { get; set; }          //aradublex 

        [DisplayName("En Üst Kat")]
        public bool HousingType_Enustkat { get; set; }      //en üst kat

        [DisplayName("Tripleks")]
        public bool HousingType_Triplex { get; set; }       //triplex

        [DisplayName("Bahçeli Dubleks")]
        public bool HousingType_Bahcedublex { get; set; }       //bahçeli dubleks

        [DisplayName("Çatıkat Dubleks")]
        public bool HousingType_Catidublex { get; set; }        //çatılı dubleks

        [DisplayName("Müstakil")]
        public bool HousingType_Mustakil { get; set; }      //müstakil 

        public string SessionString { get; set; }

        [ForeignKey("ilanId")]  
        public int AdvertId { get; set; }
        public virtual Advert ilanId { get; set; }

        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}