

namespace DsaccoAPP.Model
{
    public class Permit
    {
        public string FirstName { get;set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get;set; }
        public string Role { get; set; } = "member";       
        public string Password { get; set; }
        //public string PhoneNumber { get;set; } = string.Empty;
        //public string Address { get; set; } = string.Empty;
        //public DateTime DateOfBirth { get; set; }
        //public string Sex { get; set; } = string.Empty;
        //public string NextOfKin { get; set; } = string.Empty;
        //public string KinRelationShip { get; set; } = string.Empty;
        //public string District { get; set; } = string.Empty;
        //public string Occupation { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsPermitted { get; set; }=false;
     


    }
}
