using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200AndrewGolik.Models
{
    public class Passenger
    {
        public int passengerID { get; set; }
        public string firstName { get; set; }
        [Display (Name = "Last Name")]
        public string lastName { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public   ICollection<Flight> flights { get; set; }
    }
}