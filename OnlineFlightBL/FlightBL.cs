using OnlineFlightDAL;
using OnlineFlightDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightBL
{
    public class FlightBL
    {
        FlightDAL airlineDalObj;
        public FlightBL()
        {
            airlineDalObj = new FlightDAL();
        }
        public List<FlightTravelDTO> GetFlightDetails()
        {
            try
            {
                List<FlightTravelDTO> lstFlightDetails = airlineDalObj.FetchFlightDetails();
                return lstFlightDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateFlightPrice(FlightAirDTO airlineObj)
        {
            try
            {
                return airlineDalObj.UpdatePriceForFlight(airlineObj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
