using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("İl")]
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}