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

        public string LoggerSerialNumber { get; set; }

        [StringLength(20)]
        public string LoggerSMSNumber { get; set; }
         
        
        public DateTime LastCallIn { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SignalLevel { get; set; }
        public double BatteryLevel { get; set; }

       

       

       

      

       

        
    }
}