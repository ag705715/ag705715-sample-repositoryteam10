using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200AndrewGolik.Models
{
    public class Flight
    {
        [Display(Name ="Flight Identification")]
        [Required (ErrorMessage = "User must select airport")]
        public int flightID { get; set; }
        
        [Display (Name ="Departing Airport")]
        public string departingAirport { get; set; }
        public DateTime date { get; set; }
        public int passengerID { get; set; }
        public virtual Passenger passenger { get; set; }
        public ICollection<FlightTrack> flightTrack { get; set; }
    }
}