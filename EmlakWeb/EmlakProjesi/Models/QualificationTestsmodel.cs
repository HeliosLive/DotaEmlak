using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class QualificationTestsmodel
    {
        public string Side_North { get; set; }  //kuzey cephesi
        public string Side_South { get; set; }  //güney cephesi
        public string Side_West { get; set; }  //batı cephesi
        public string Side_East { get; set; }  //doğu cephesi
        public string RoomType_TV { get; set; }   //televizyon
        public string RoomType_Tel { get; set; }  //telefon 
        public string RoomType_MoneyCase { get; set; }   //parakasası
        public string RoomType_Closet { get; set; }  //dolap
        public string RoomType_WashingMachine { get; set; }  //çamaşır makinesi
        public string RoomType_DishWasher { get; set; }  //bulaşık makinesi
        public string RoomType_LaundryRoom { get; set; }  //çamaşır odası
        public string RoomType_AirConditioner { get; set; }  //airconditior klima
        public string RoomType_Cellar { get; set; }   //Kiler 
        public string RoomType_Balcony { get; set; }  //balkon
        public string RoomType_Terrace { get; set; }  //teras
        public string RoomType_Barbeque { get; set; }  //barbekü
        public string RoomType_WhiteAppliances { get; set; }   //beyaz eşya
        public string RoomType_Refrigerator { get; set; }  //Buzdolabı
        public string RoomType_ParentBath { get; set; }   //Ebeveyn Banyosu
        public string RoomType_Kartonpiyer { get; set; }  //Kartonpiyer
        public string RoomType_Ankastre { get; set; }    //Ankastre
        public string RoomType_Laminant { get; set; }   //laminant zemin
        public string RoomType_Panjur { get; set; }  //Panjur
        public string RoomType_Furniture { get; set; }  //Mobilya 
        public string RoomType_SteelDoor { get; set; }   //çelik kapı
        public string RoomType_Thermopane { get; set; }  //ısıcam
        public string RoomType_SeramikGround { get; set; }   //seramik zemin
        public string RoomType_ParkeGround { get; set; }      //parke zemin
        public string RoomType_FirePlace { get; set; }   //şömine
        public string BathroomType_Tub { get; set; }  //küvet
        public string BathroomType_Jacuzzi { get; set; } //jakuzi
        public string BathroomType_Cabin { get; set; }  //duşakabin
        public string BathroomType_Alaturka { get; set; }  //tuvalet tipi
        public string BathroomType_Alafranga { get; set; }  //tuvalet tipi
        public string ViewType_Mountain { get; set; }  //MANZARA _ dağ
        public string ViewType_Sea { get; set; }      //deniz
        public string ViewType_Bosphorus { get; set; }      //boğaz 
        public string ViewType_Forest { get; set; }    //orman
        public string ViewType_City { get; set; }     //şehir
        public string ViewType_Historical { get; set; }  //tarihi
        public string GroundType_ADSL { get; set; }   // ALTYAPI _adsl internet
        public string GroundType_Fiber { get; set; }  //fiber internet
        public string GroundType_Wifi { get; set; }   //wifi mesela sitelerde otomatik wifi
        public string GroundType_CableTV { get; set; }  //kablolu TV
        public string Environment_PreSchool { get; set; }    //ÇEVRE _ilkokul
        public string Environment_MidSchool { get; set; }    //ortaokul
        public string Environment_University { get; set; }    //üniversite
        public string Environment_Hospital { get; set; }      //hastane
        public string Environment_Mosque { get; set; }        //cami
        public string Environment_Avm { get; set; }       //alışveriş merkezi
        public string Environment_Municipality { get; set; }          //belediye
        public string Environment_Market { get; set; }        //market
        public string Environment_FunLand { get; set; }       //eğlence merkezi
        public string Environment_Police { get; set; }        //karakol
        public string Environment_Park { get; set; }      //park yeri var mı çevrede
        public string Transport_Bus { get; set; }     //ULAŞIM _ otobüs
        public string Transport_Minibus { get; set; }     //minibüs
        public string Transport_Subway { get; set; }      //metro
        public string Transport_Tem { get; set; }     //tem yolu
        public string Transport_E5 { get; set; }      //E5
        public string Transport_Metrobus { get; set; }        //metrobüs
        public string Transport_Teleferik { get; set; }       //teleferik
        public string Transport_Tramvay { get; set; } //tramvay
        public string Transport_Pier { get; set; }  //iskele
        public string Transport_Airport { get; set; }  //havaalanı
        public string HousingType_Arakat { get; set; }  // KONUT tipleri türkçe bu kısım_ arakat daire
        public string HousingType_Bahceli { get; set; }   //bahçe kat
        public string HousingType_Bahcekati { get; set; }     //bahçe katı    
        public string HousingType_TersDublex { get; set; }        //ters dubleks
        public string HousingType_Arakatdublex { get; set; }          //aradublex 
        public string HousingType_Enustkat { get; set; }      //en üst kat
        public string HousingType_Triplex { get; set; }       //triplex
        public string HousingType_Bahcedublex { get; set; }       //bahçeli dubleks
        public string HousingType_Catidublex { get; set; }        //çatılı dubleks
        public string HousingType_Mustakil { get; set; }      //müstakil
 
    }
}