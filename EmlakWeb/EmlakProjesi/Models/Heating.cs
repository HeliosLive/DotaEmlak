using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class Heating
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; } //doğalgaz,merkezi ısıtma,soba vsvs...
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}