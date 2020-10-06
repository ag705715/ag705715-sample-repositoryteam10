using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200AndrewGolik.Models
{
    public class FlightTrack
    {

        
        public int flightTrackID{ get; set; }
        public decimal price { get; set; }
        public int ticketID { get; set; }
        public int flightID { get; set; }
        public virtual Flight flight { get; set; }
        
    }
}