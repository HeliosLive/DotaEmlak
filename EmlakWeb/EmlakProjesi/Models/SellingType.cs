using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class SellingType
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Satış Tipi")]
        public string Ad { get; set; }  // satılık,kiralık,günlük,devren vs.
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}