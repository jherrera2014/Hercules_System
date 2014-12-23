using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hercules.Models
{
    public class GoogleMarker
    {
        public double LatEast { get; set; }
        public double LongNorth { get; set; }
        public string Address { get; set; }
        public string ZoneName { get; set; }
        public string Notes { get; set; }

    }
}