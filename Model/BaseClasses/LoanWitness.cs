

namespace DsaccoAPP.Model.BaseClasses
{
    public class LoanWitness
    {       
        public int LoanWitnessId { get; set; }
        public string FirstWitnessName { get; set; } = string.Empty;
        public string FirstWitnessAddress { get; set; } = string.Empty;
        public string FirstWitnessContact { get; set; } = string.Empty;
        public string SecondWitnessName { get; set; } = string.Empty;
        public string SecondWitnessAddress { get; set; } = string.Empty;
        public string SecondWitnessContact { get; set; } = string.Empty;


    }
}
