using Newtonsoft.Json;
using OnlineFlightBL;
using OnlineFlightDTO;
using OnlineFlightMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineFlightMVC.Controllers
{
    public class OnlineFlightMVCController : Controller
    {
        FlightBL blObj;
        public OnlineFlightMVCController()
        {
            blObj = new FlightBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> DisplayFlightDetailsUsingWebAPI()
        {
            try
            {
                string baseURL = $"http://localhost:63215/";
                string routeURL = $"api/Airlines/DisplayFlights";
                var apiClient = new HttpClient();
                apiClient.BaseAddress = new Uri(baseURL);
                apiClient.DefaultRequestHeaders.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage apiResponse = await apiClient.GetAsync(routeURL);
                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = apiResponse.Content.ReadAsStringAsync().Result;
                    var finalResult = JsonConvert.DeserializeObject<List<TravelModel>>(result);
                    return View(finalResult);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult UpdateFlightPrice()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult UpdateFlightPrice(Airliness fligthPriceDetails)
        {
            try
            {
                FlightAirDTO airlineObj = new FlightAirDTO();
                airlineObj.airlineId = fligthPriceDetails.airlineId;
                airlineObj.travelDate = fligthPriceDetails.travelDate;
                airlineObj.price = fligthPriceDetails.price;
                int returnValue = blObj.UpdateFlightPrice(airlineObj);
                if (returnValue == 1)
                {
                    return RedirectToAction("DisplayFlightDetailsUsingWebAPI");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
    }
}