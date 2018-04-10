using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmlakProjesi.Models
{
    public class UserRole
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }
    }
}