using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hercules.Models
{
    public class GoogleMarker
    {
        public string SiteName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string InfoWindow { get; set; }
    }
}