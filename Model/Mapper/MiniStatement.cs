

namespace DsaccoAPP.Model.Mapper
{
    public class MiniStatement
    {
        public UserDataDto UserDataDto {  get; set; }
        public double TotalShares { get; set; } = 0L;
        public decimal LoanBalance { get; set; } = 0M;
        public decimal AccountBalance { get; set; } = 0M;

      
    }
}
