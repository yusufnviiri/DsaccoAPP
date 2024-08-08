namespace DsaccoAPP.Model.BaseClasses
{
    public class AccountOperations
    {
        public User? User { get; set; }
        public string Reason { get; set; }=string.Empty;

        public Account? Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string StringDate { get; set; } = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";


    }
}
