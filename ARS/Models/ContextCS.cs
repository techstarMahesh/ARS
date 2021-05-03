using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ARS.Models;
using ARS.Controllers;

namespace ARS.Models
{
    public class ContextCS : DbContext
    {
        public ContextCS() : base("cs")
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<AeroPlaneInfo> PlaneInfo { get; set; }
        public DbSet<FlightBooking> FlightsBookings { get; set; }

    }
}