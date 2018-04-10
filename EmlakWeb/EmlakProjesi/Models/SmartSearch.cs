using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class SmartSearch
    {
        public string title { get; set; }
        public List<int> city { get; set; }
       // public string district { get; set; }
        //public string room { get; set; }
        //public string selling { get; set; }
        //public string heating { get; set; }
        public string maxfiyat { get; set; }
        public string minfiyat { get; set; }
        public string maxmetre { get; set; }
        public string minmetre { get; set; }
        //public List<int> DistrictId { get; set; }
        public List<int> DistrictId { get; set; }
        public List<int> RoomId { get; set; }
        public List<int> SellingTypeId { get; set; }
        public List<int> HeatingId { get; set; }
    }
} 
 