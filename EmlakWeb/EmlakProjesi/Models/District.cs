using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class District
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("İlçe")]
        public string Name { get; set; }


        [DisplayName("İl Id")]
        public int CityId { get; set; }

        [DisplayName("İl Adı")]
        public string CityName { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }

    }
}
