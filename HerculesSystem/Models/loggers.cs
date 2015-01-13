//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HerculesSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class loggers
    {
        public int ID { get; set; }
        public string LoggerType { get; set; }
        public string LoggerSoftware { get; set; }
        public string LoggerSerialNumber { get; set; }
        public string LoggerSMSNumber { get; set; }
        public string LoggerGSMNumber { get; set; }
        public Nullable<int> OwnerAccount { get; set; }
        public Nullable<System.DateTime> LastCallIn { get; set; }
        public Nullable<System.DateTime> RST { get; set; }
        public Nullable<int> SignalLevel { get; set; }
        public Nullable<double> BatteryLevel { get; set; }
        public Nullable<int> LogRateMs { get; set; }
        public Nullable<int> NetID { get; set; }
        public Nullable<int> LAC { get; set; }
        public Nullable<int> CellID { get; set; }
        public Nullable<double> MastLongitude { get; set; }
        public Nullable<double> MastLatitude { get; set; }
        public Nullable<long> DataCount { get; set; }
        public string Notes { get; set; }
        public string LastMessageType { get; set; }
        public Nullable<int> CallFrequency { get; set; }
        public int CompanyID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<bool> LoggerStatus { get; set; }
    
        public virtual company company { get; set; }
    }
}
