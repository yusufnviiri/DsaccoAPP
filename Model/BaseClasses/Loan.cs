
namespace DsaccoAPP.Model.BaseClasses
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public LoanType LoanType { get; set; }
        public LoanWitness LoanWitness { get; set; } = new LoanWitness();
        public int NumberOfInstallments { get; set; } = 0;
        public int NumberOfPayments { get; set; } = 0;
        public decimal PayAmount { get; set; }
        public decimal OutstandingBalance { get; set; }
        public double LoanInterest { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; } = false;
        public decimal PrincipleAmount { get; set; } = 0M;
        public string Security { get; set; } = "Salary";
        public int LoanPeriod { get; set; } = 0;
        public void SetInterest(string loanType)
        {
            LoanInterest = loanType switch
            {
                "School Fees Loan" => 0.11,
                "Salary Loan" => 0.15,
                "Emergency Loan" => 0.19,
                "Special Loan" => 0.20,
                _ => 0.11,
            };
        }
  

    }
}
