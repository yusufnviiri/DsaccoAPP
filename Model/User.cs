

using DsaccoAPP.Model.BaseClasses;

namespace DsaccoAPP.Model
{
    public class User : Permit
    {  public int UserId { get;set; }
        public IEnumerable<Account>? Accounts { get; set; } = new List<Account>();
        public IEnumerable<Deposit>? Deposits { get; set; }= new List<Deposit>();  
        public IEnumerable<Withdraw>? Withdraws { get; set; } = new List<Withdraw>();
        public IEnumerable<Loan>? Loans { get; set; } =  new List<Loan>();
        //public User loggedInUser {  get; set; }=new User();
        //public User CheckLoginStatus(User user)
        //{
        //    if (user.IsPermitted)
        //    {
        //        this.loggedInUser = user;
        //    }

        //    return loggedInUser;

        //}
    }
}

