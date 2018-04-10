using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public string ImageId { get; set; }
        public string SessionString { get; set; }
        public int AdvertId { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}