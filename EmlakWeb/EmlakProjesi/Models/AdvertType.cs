using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class AdvertType
    {
        //premium ya da normal bir ilan mı onu belirler buradaki bilgiler.
        [Key]
        public int ID { get; set; }
        public int AdvertId { get; set; }
        public bool Premium { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}