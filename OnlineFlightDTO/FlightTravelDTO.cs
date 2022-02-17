using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightDTO
{
    public class FlightTravelDTO
    {
        public int airlineId { get; set; }
        public string sourceCity { get; set; }
        public System.DateTime travelDate { get; set; }
        public string airlineName { get; set; }
        public string destinationCity { get; set; }
        public int price { get; set; }
        public string travelTime { get; set; }
    }
}
