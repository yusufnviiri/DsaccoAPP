namespace DsaccoAPP.Model.BaseClasses
{
    public class MemberShares
    {
        public int MemberSharesId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public double NumberOfShares { get; set; } = 0L;
        public decimal ValueOfShare { get; set; } = 0L;    
    }
}
