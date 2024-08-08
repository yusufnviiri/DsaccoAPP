using System.ComponentModel.DataAnnotations.Schema;

namespace DsaccoAPP.Model.BaseClasses
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal CurrentBalance { get; set; } = 0M;
        public decimal InitialDeposit { get; set; } = decimal.Zero;
        public decimal OpeningAmount { get; set; } = 0M;
        public User? User { get; set; }
        public string OpeningDate { get; set; } = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
        public DateTime ClosingDate { get; set; } = DateTime.MaxValue;
        public string AccountDescription { get; set; }
        //public enum AccountType { Savings = 0, Fixed = 1, Bussiness = 3 }

        public void OpenACount(decimal amount, string decription)
        {
            OpeningAmount = amount;

            AccountDescription = decription.ToLower() switch
            {
                "saving" => "Savings",
                "fixed" => "Fixed",
                "bussiness" => "Bussiness",
                _ => "Savings",
            };


        }

        public void UpdateCurrentBalance(decimal amount)
        {
            CurrentBalance = amount;
        }

    }
}
