namespace ARS.Migrations
{
    using ARS.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextCS>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextCS context)
        {
            var userAccounts = new List<UserAccount>
            {
                new UserAccount { UserId = 1, FirstName = "admin", Lastname = "admin", Age= "23", Password="admin@1234", CPassword="admin@1234", UserName="admin", Email="admin@gmail.com", PhoneNo="9918343234", CNIC="3499857439467" },
            };
            userAccounts.ForEach(s => context.UserAccounts.AddOrUpdate(s));
            context.SaveChanges();

            var adminLogin = new List<AdminLogin>
            {
               new AdminLogin { AdminID = 1, AdminName = "admin", AdminPassword = "admin@1234" },
            };
            adminLogin.ForEach(s => context.AdminLogins.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
