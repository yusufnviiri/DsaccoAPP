
namespace DsaccoAPP.Model.Mapper
{
    public class loanModel
    {
        public int LoanType { get; set; }
        public int NumberOfInstallments { get; set; } = 0;
        public decimal PrincipleAmount { get; set; } = 0M;
        public string Security { get; set; } = "Salary";
        public int LoanPeriod { get; set; } = 0;
        public string FirstWitnessName { get; set; }
        public string FirstWitnessAddress { get; set; }
        public string FirstWitnessContact { get; set; }
        public string SecondWitnessName { get; set; }
        public string SecondWitnessAddress { get; set; }
        public string SecondWitnessContact { get; set; }
    }
}
