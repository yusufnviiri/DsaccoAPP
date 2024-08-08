
namespace DsaccoAPP.Model.BaseClasses
{
    public class LoanPayment
    {
        public int LoanPaymentId { get; set; }
        public Loan Loan { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; } = DateTime.Now;
  

    }

}
