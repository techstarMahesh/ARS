namespace ARS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        AdminPassword = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.AdminID);

            CreateTable(
                "dbo.TblFlightBook",
                c => new
                {
                    bId = c.Int(nullable: false, identity: true),
                    bCusName = c.String(nullable: false, unicode: false),
                    To = c.String(nullable: false, unicode: false),
                    bCusEmail = c.String(nullable: false, unicode: false),
                    bCusSeats = c.String(nullable: false, unicode: false),
                    bCusPhone = c.String(nullable: false, unicode: false),
                    bCusCnic = c.String(nullable: false, unicode: false),
                    ResId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.bId)
                .ForeignKey("dbo.TicketReservation_tbl", t => t.ResId, cascadeDelete: true);
            Sql("CREATE index `ResId` on `TblFlightBook` (`ResId` DESC)");

            CreateTable(
                "dbo.TicketReservation_tbl",
                c => new
                {
                    ResId = c.Int(nullable: false, identity: true),
                    RestFrom = c.String(nullable: false, unicode: false),
                    RestTo = c.String(nullable: false, unicode: false),
                    RestDepDate = c.String(nullable: false, unicode: false),
                    RestTime = c.String(nullable: false, unicode: false),
                    PlaneID = c.Int(nullable: false),
                    PlaneSeats = c.Int(nullable: false),
                    ResTicketPrice = c.Single(nullable: false),
                    ResPlaneType = c.String(nullable: false, unicode: false),
                })
                .PrimaryKey(t => t.ResId)
                .ForeignKey("dbo.AeroPlaneInfoes", t => t.PlaneID, cascadeDelete: true);
                Sql("CREATE index `PlaneID` on `TicketReservation_tbl` (`PlaneID` DESC)");

            CreateTable(
                "dbo.AeroPlaneInfoes",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        planeName = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
                        Lastname = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        CPassword = c.String(maxLength: 16, storeType: "nvarchar"),
                        Age = c.String(nullable: false, maxLength: 11, storeType: "nvarchar"),
                        PhoneNo = c.String(nullable: false, maxLength: 11, storeType: "nvarchar"),
                        CNIC = c.String(nullable: false, maxLength: 13, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblFlightBook", "ResId", "dbo.TicketReservation_tbl");
            DropForeignKey("dbo.TicketReservation_tbl", "PlaneID", "dbo.AeroPlaneInfoes");
            DropIndex("dbo.TicketReservation_tbl", new[] { "PlaneID" });
            DropIndex("dbo.TblFlightBook", new[] { "ResId" });
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.AeroPlaneInfoes");
            DropTable("dbo.TicketReservation_tbl");
            DropTable("dbo.TblFlightBook");
            DropTable("dbo.TblAdminLogin");
        }
    }
}
