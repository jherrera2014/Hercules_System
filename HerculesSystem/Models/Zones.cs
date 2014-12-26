using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HerculesSystem.Models
{
    public class Zones 
    {
        public int ID { get; set; }

        [Required]
        public string ZoneName { get; set; }

        public System.Nullable<System.DateTime> CreationDate { get; set; }

        public System.Nullable<bool> Status { get; set; }

        
    }
}