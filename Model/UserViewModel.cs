namespace DsaccoAPP.Model
{
    public class UserViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "member";
        public bool IsPermitted { get; set; } = false;


    }
}
