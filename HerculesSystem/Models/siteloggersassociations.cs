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
    
    public partial class siteloggersassociations
    {
        public int ID { get; set; }
        public Nullable<int> SiteID { get; set; }
        public Nullable<int> LoggerID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}