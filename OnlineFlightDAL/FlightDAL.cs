using OnlineFlightDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightDAL
{
    public class FlightDAL
    {
        SqlConnection connectionObject;
        FlightsDBContext contextObject;
        SqlCommand commandObject;
        public FlightDAL()
        {
            connectionObject = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineFlightString"].ConnectionString);
            contextObject = new FlightsDBContext();
        }

        public List<FlightTravelDTO> FetchFlightDetails()
        {
            try
            {
                var listOfFlights = (from flight in contextObject.Travels
                                     from fly in contextObject.Airlines
                                     where flight.AirlinesID == fly.AirlinesID
                                     select new
                                     {
                                         flight.AirlinesID,
                                         fly.AirlinesName,
                                         flight.SourceCity,
                                         flight.Destination,
                                         flight.TravelDate,
                                         flight.TravelTime,
                                         flight.Price,
                                     }).ToList();
                List<FlightTravelDTO> listOfFlightDetails = new List<FlightTravelDTO>();
                foreach (var flightDetails in listOfFlights)
                {
                    listOfFlightDetails.Add(new FlightTravelDTO()
                    {
                        airlineId = (int)flightDetails.AirlinesID,
                        airlineName = flightDetails.AirlinesName,
                        sourceCity = flightDetails.SourceCity,
                        destinationCity = flightDetails.Destination,
                        travelDate = flightDetails.TravelDate,
                        travelTime = flightDetails.TravelTime,
                        price = (int)flightDetails.Price,
                    });
                }
                return listOfFlightDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdatePriceForFlight(FlightAirDTO airlineObj)
        {
            try
            {
                commandObject = new SqlCommand();
                commandObject.CommandText = "uspUpdateFilghtPrice";
                commandObject.CommandType = System.Data.CommandType.StoredProcedure;
                commandObject.Connection = connectionObject;
                commandObject.Parameters.AddWithValue("@AirlinesID", airlineObj.airlineId);
                commandObject.Parameters.AddWithValue("@price", airlineObj.price);
                commandObject.Parameters.AddWithValue("@traveldate",airlineObj.travelDate);

                SqlParameter returnValue = new SqlParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                returnValue.SqlDbType = SqlDbType.Int;
                commandObject.Parameters.Add(returnValue);

                connectionObject.Open();
                commandObject.ExecuteNonQuery();
                return Convert.ToInt32(returnValue.Value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connectionObject.Close();
            }
        }
    }
}
