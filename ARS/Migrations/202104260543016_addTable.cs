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
                        From = c.String(nullable: false, maxLength: 40),
                        To = c.String(nullable: false, maxLength: 40),
                        DDate = c.String(nullable: false),
                        DTime = c.String(nullable: false, maxLength: 15),
                        PlaneId = c.Int(nullable: false),
                        SeatType = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.bId)
                .ForeignKey("dbo.AeroPlaneInfoes", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.PlaneId);
            
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
            DropForeignKey("dbo.TblFlightBook", "PlaneId", "dbo.AeroPlaneInfoes");
            DropIndex("dbo.TblFlightBook", new[] { "PlaneId" });
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.AeroPlaneInfoes");
            DropTable("dbo.TblFlightBook");
            DropTable("dbo.TblAdminLogin");
        }
    }
}
