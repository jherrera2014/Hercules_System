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
    
    public partial class alarmTypes
    {
        public alarmTypes()
        {
            this.alarms = new HashSet<alarms>();
        }
    
        public int AlarmTypeId { get; set; }
        public string AlarmType { get; set; }
        public Nullable<int> AlarmTypeCode { get; set; }
        public Nullable<int> Channel { get; set; }
    
        public virtual ICollection<alarms> alarms { get; set; }
    }
}
