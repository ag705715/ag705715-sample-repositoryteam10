using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MIS4200AndrewGolik.Models;

namespace MIS4200AndrewGolik.DAL
{
    public class MIS4200AndrewGolikContext : DbContext
    {
        public MIS4200AndrewGolikContext():base ("name=DefaultConnection")
        {

        }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Flight>  flights  { get; set; }
        public DbSet<FlightTrack> flightTracks  { get; set; }
      


    }


}