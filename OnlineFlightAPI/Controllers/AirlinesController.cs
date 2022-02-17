using OnlineFlightBL;
using OnlineFlightDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFlightAPI.Controllers
{
    public class AirlinesController : ApiController
    {
        FlightBL airlineBlObj;
        public AirlinesController()
        {
            airlineBlObj = new FlightBL();
        }

        [HttpGet]
        public HttpResponseMessage DisplayFlights()
        {
            try
            {
                List<FlightTravelDTO> listOfFlightDetails = airlineBlObj.GetFlightDetails();
                if (listOfFlightDetails.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listOfFlightDetails);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "No Flight Details Available");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
