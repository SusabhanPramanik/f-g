using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineFlightMVC.Models
{
    public class TravelModel
    {
        [DisplayName("AirlinessID")]
        public int airlineId { get; set; }
        [DisplayName("AirlinessName")]
        public string airlineName { get; set; }
        [DisplayName("Source")]
        public string sourceCity { get; set; }
        [DisplayName("Destination")]
        public string destinationCity { get; set; }
        [DisplayName("TravelDate")]
        public System.DateTime travelDate { get; set; }
        [DisplayName("TravelTime")]
        public string travelTime { get; set; }
        [DisplayName("Price")]
        public int price { get; set; }
    }
}