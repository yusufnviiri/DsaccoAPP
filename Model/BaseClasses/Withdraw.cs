

namespace DsaccoAPP.Model.BaseClasses
{
    public class Withdraw : AccountOperations
    {
        public int WithdrawId { get; set; }
        public bool IswithdrawValid(decimal withdrawAmount, Account account)
        {
            if (account.CurrentBalance > withdrawAmount)
            {
                account.CurrentBalance -= Amount;
                return true;
            }
            return false;
        }

    }
}
