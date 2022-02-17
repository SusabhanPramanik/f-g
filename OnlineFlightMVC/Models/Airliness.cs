using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightMVC.Models
{
    public class Airliness
    {
        [DisplayName("AirlineID")]
        [Required(ErrorMessage = "AirlineID name should not be empty.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "AirlineID must have only numbers")]
        public int airlineId { get; set; }
        [DisplayName("TravelDate")]
        public System.DateTime travelDate { get; set; }
        [DisplayName("Price")]
        [Required(ErrorMessage = "Price name should not be empty.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Price must have only numbers")]
        public int price { get; set; }
    }
}