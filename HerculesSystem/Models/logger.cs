using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


using System.Web;

namespace HerculesSystem.Models
{
    [Table("loggers")]
    public partial class logger
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string LoggerType { get; set; }

        [Required(ErrorMessage= "Campo obligatorio.")]
        public string LoggerSerialNumber { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Solo números")]
        public string LoggerSMSNumber { get; set; }
         
        
        public DateTime LastCallIn { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SignalLevel { get; set; }
        public double BatteryLevel { get; set; }

        public string LoggerGSMNumber { get; set; }

        public int LoggerRateMs { get; set; }
       
        public string Notes { get; set; }

        public string owner_name { get; set; }

        public int SitedID { get; set; }

        public int OwnerAccount { get; set; }

        public bool WithSite { get; set; }




       

       

       

      

       

        
    }
}