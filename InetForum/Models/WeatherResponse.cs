using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }
    }
}