namespace ARS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 10),
                        AdminPassword = c.String(nullable: false, maxLength: 16),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.TblFlightBook",
                c => new
                    {
                        bId = c.Int(nullable: false, identity: true),
                        bCusName = c.String(nullable: false),
                        To = c.String(nullable: false),
                        bCusEmail = c.String(nullable: false),
                        bCusSeats = c.String(nullable: false),
                        bCusPhone = c.String(nullable: false),
                        bCusCnic = c.String(nullable: false),
                        ResId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bId)
                .ForeignKey("dbo.TicketReservation_tbl", t => t.ResId, cascadeDelete: true)
                .Index(t => t.ResId);
            
            CreateTable(
                "dbo.TicketReservation_tbl",
                c => new
                    {
                        ResId = c.Int(nullable: false, identity: true),
                        RestFrom = c.String(nullable: false),
                        RestTo = c.String(nullable: false),
                        RestDepDate = c.String(nullable: false),
                        RestTime = c.String(nullable: false),
                        PlaneID = c.Int(nullable: false),
                        PlaneSeats = c.Int(nullable: false),
                        ResTicketPrice = c.Single(nullable: false),
                        ResPlaneType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResId)
                .ForeignKey("dbo.AeroPlaneInfoes", t => t.PlaneID, cascadeDelete: true)
                .Index(t => t.PlaneID);
            
            CreateTable(
                "dbo.AeroPlaneInfoes",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        planeName = c.String(nullable: false, maxLength: 16),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 8),
                        FirstName = c.String(nullable: false, maxLength: 8),
                        Lastname = c.String(nullable: false, maxLength: 8),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 16),
                        CPassword = c.String(maxLength: 16),
                        Age = c.String(nullable: false, maxLength: 11),
                        PhoneNo = c.String(nullable: false, maxLength: 11),
                        CNIC = c.String(nullable: false, maxLength: 13),
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
