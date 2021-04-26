using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ARS.Models
{
    // This is for the create a table name and there name is Admin Login
    [Table("TblAdminLogin")]
    public class AdminLogin
    {

        //It is create a id and then assigne the values is primary key
        [Key]
        public int AdminID { get; set; }

        //This is for the Admin UserName
        [Required(ErrorMessage = "User Name is Requard")]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        [MinLength(4, ErrorMessage = "Mininum Length 4 Carrecter are allows"), MaxLength(10, ErrorMessage = "Maximum 10 Carrecter are Allows")]
        public string AdminName { get; set; }

        //This is for the Admin Password
        [Required(ErrorMessage = "User Name is Requard")]
        [DataType(DataType.Text)]
        [MinLength(8, ErrorMessage = "Mininum Length 8 Carrecter are allows"), MaxLength(16, ErrorMessage = "Maximum 16 Carrecter are Allows")]
        [Display(Name = "Password")]
        public string AdminPassword { get; set; }
    }
    [Table("TblUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        //User Name
        [Required(ErrorMessage = "User Name is Requared")]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        [MinLength(4, ErrorMessage = "Minimum Length 4 Charecter are allows"), MaxLength(8, ErrorMessage = "Maximum 10 carrecter are allows")]
        public string UserName { get; set; }

        //User First Name
        [Required(ErrorMessage = "User Name is Requared")]
        [DataType(DataType.Text)]
        [Display(Name = "lastname")]
        [MinLength(4, ErrorMessage = "Minimum Length 4 Charecter are allows"), MaxLength(8, ErrorMessage = "Maximum 10 carrecter are allows")]
        public string FirstName { get; set; }

        //User Last Name
        [Required(ErrorMessage = "User Name is Requared")]
        [DataType(DataType.Text)]
        [Display(Name = "lastname")]
        [MinLength(4, ErrorMessage = "Minimum Length 4 Charecter are allows"), MaxLength(8, ErrorMessage = "Maximum 10 carrecter are allows")]
        public string Lastname { get; set; }

        //User Email ID
        [Required(ErrorMessage = "Email ID is Requared")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Id")]
        [MaxLength(30, ErrorMessage = "Maximum 30 Carrecter are allows")]
        public string Email { get; set; }

        //User Password
        [Required(ErrorMessage = "User Password is Requard")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 carrecter are allows"), MaxLength(16, ErrorMessage = "Maximum 16 Carrecter are allows")]
        public string Password { get; set; }

        //User Conform Password
        [Compare("Password", ErrorMessage = "Password not matched")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 carrecter are allows"), MaxLength(16, ErrorMessage = "Maximum 16 Carrecter are allows")]
        public string CPassword { get; set; }

        // User Age
        [Required(ErrorMessage = "Age are Requard")]
        [Range(minimum: 18, maximum: 80, ErrorMessage = "Minimum 18 Years and Maximum 80 Years")]
        [StringLength(11)]
        public string Age { get; set; }

        //User Phone Number
        [Required(ErrorMessage = "Phone Number are requard"), RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Correct Massage")]
        [Display(Name = "Phone Number")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        //User NIC Number
        [Required(ErrorMessage = "CNIC Number are requard"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "CNIC Number is Incorrect")]
        [StringLength(13)]
        public string CNIC { get; set; }
    }

    /* Shit capicaty
     * Plane Number
     * Plane Nomber of shits
     * Plane Name
     */
    //[Table("TblPlaneInfo")]
    public class AeroPlaneInfo
    {
        // Plane Number
        [Key]
        public int PlaneId { get; set; }

        //Plane Name
        [Required(ErrorMessage = "Plane Name is Requred")]
        [MinLength(4, ErrorMessage = "Minimum 4 Carrecter are allows"), MaxLength(16, ErrorMessage = "Maximum 16 Carrecter are allows")]
        [Display(Name = "planeName")]
        public string planeName { get; set; }

        // Plane Sheating Capicaty
        [Required(ErrorMessage = "Plane Shitting capicaty are requard")]
        [Display(Name = "SeatingCapacity")]
        public int SeatingCapacity { get; set; }

        //Plane Price
        [Required(ErrorMessage = "Plane price are requard")]
        [Display(Name = "planePrice")]
        public float Price { get; set; }
    }
    [Table("TblFlightBook")]
    public class FlightBooking
    {
        [Key]
        public int bId { get; set; }

        //Coustumer From
        [Required(ErrorMessage = "From City is Requard")]
        [Display(Name ="From City Name")]
        [StringLength(40,ErrorMessage ="Max 40 Charecter are allows")]
        public string From { get; set; }
        
        //Coustumer To
        [Required(ErrorMessage = "From City is Requard")]
        [Display(Name = "From City Name")]
        [StringLength(40, ErrorMessage = "Max 40 Charecter are allows")]
        public string To { get; set; }

        //Diparcher Date
        [Required(ErrorMessage = "Departucher Date is Requard")]
        [Display(Name = "Departucher Date")]
        [DataType(DataType.Date)]
        public string DDate { get; set; }

        //Diperchaer Time
        [Required(ErrorMessage = "Departucher Time is Requard")]
        [Display(Name = "Departucher Time")]
        [DataType(DataType.Time)]
        [StringLength(15)]
        public string DTime { get; set; }

        //Foren Key
        public int PlaneId { get; set; }
        public virtual AeroPlaneInfo PlaneInfo { get; set; }

        // Seat type like general or economy
        [Display(Name ="Seat Type")]
        [StringLength(25)]
        public string SeatType { get; set; }



        /*

        //Coustumer Address
        [Required(ErrorMessage = "Coustumer Address is Requard")]
        public string To { get; set; }

        //Coustumer Email
        [Required(ErrorMessage = "Coustumer Email is Requard")]
        public string bCusEmail { get; set; }

        //Coustumer Name
        [Required(ErrorMessage = "Number of Seats")]
        public string bCusSeats { get; set; }

        //Coustumer Phone Number
        [Required(ErrorMessage = "Coustumer Name is Phone Number")]
        public string bCusPhone { get; set; }

        //Coustumer CNIC
        [Required(ErrorMessage = "Coustumer CNIC is Requard")]
        public string bCusCnic { get; set; }

        //Reservation ID
        public int ResId { get; set; }
        public virtual TicketReservation_tbl TicketResevation_tbls { get; set; }
        

        */

    }


    /*
    public class TicketReservation_tbl
    {
        [Key]
        public int ResId { get; set; }

        //Flight where from you take
        [Required, Display(Name = "From City: ")]
        public string RestFrom { get; set; }

        //Flight Booking To city Date
        [Required, Display(Name = "To City: ")]
        public string RestTo { get; set; }

        //Flight Taking Date
        [Required, Display(Name = "Date: ")]
        public string RestDepDate { get; set; }

        //Which time Flight Booking you want
        [Required, Display(Name = "Time: ")]
        public string RestTime { get; set; }

        //Flight Booking Plane Number or ID
        [Required, Display(Name = "Plane ID: ")]
        public int PlaneID { get; set; }
        public virtual PlatformID Plane_tbls { get; set; }

        //Flight Seats Aribility
        [Required, Display(Name = "Seat Ability: ")]
        public int PlaneSeats { get; set; }

        //Flight Booing Price
        [Required, Display(Name = "Price: ")]
        public float ResTicketPrice { get; set; }

        //Flight Booking Number
        [Required, Display(Name = "Plane Type: ")]
        public string ResPlaneType { get; set; }
        public virtual ICollection<flightBooking> tblFlightBookings { get; set; }

    }

    */
}