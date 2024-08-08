namespace DsaccoAPP.Model.BaseClasses
{
    public class Share
    {
        public int ShareId { get; set; }
        public double SharesAmount { get; set; } = 0L;
        public double NumberOfShares { get; set; } = 7000;
        public double SharesAvailable { get; set; } = 7000;
        public decimal ShareValue { get; set; } = 2100;
        public double MaxNumberOfShares { get; set; } = 200;
    }
}
