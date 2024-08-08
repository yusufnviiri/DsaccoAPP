

namespace DsaccoAPP.Model.BaseClasses
{
    public class UserData
    {
        
        public int UserDataId { get; set; }
        public User? User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string NextOfKin { get; set; } = string.Empty;
        public string KinRelationShip { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public int Age { get; set; }

      

    }
}
