

namespace DsaccoAPP.Model.BaseClasses
{
    public class Deposit : AccountOperations
    {
        public int DepositId { get; set; }

        public DateTime DepositDate { get; set; } = DateTime.Now;
        public void UpdateAccountBalance(decimal depositAmount, Account userAccount)
        {
            if (userAccount.InitialDeposit == 0)
            {
                userAccount.InitialDeposit = userAccount.CurrentBalance;
            }

            userAccount.CurrentBalance += depositAmount;
        }

    }
}
