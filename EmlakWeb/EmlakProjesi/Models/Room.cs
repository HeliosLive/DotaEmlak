using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Oda Sayısı")]
        public string Ad { get; set; } // 3+1,2+1,4+1,3+2  vsvs...
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}