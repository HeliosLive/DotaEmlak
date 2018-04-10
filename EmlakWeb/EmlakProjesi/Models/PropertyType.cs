using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class PropertyType
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Emlak Tipi")]
        public string Ad { get; set; } // apartman,villa,plaza,arazi vsvs...
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}