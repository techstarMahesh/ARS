using System.Data.Entity;

namespace ARS.Models
{
    [DbConfigurationType(typeof(MySql.Data.MySqlClient.MySqlConfiguration))]
    public class ContextCS : DbContext
    {
        public ContextCS() : base("name=cs")
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<AeroPlaneInfo> PlaneInfo { get; set; }
        public DbSet<FlightBooking> FlightsBookings { get; set; }

        public System.Data.Entity.DbSet<ARS.Models.TicketReservation_tbl> TicketReservation_tbl { get; set; }
    }
}