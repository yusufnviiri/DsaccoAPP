using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaccoAPP.Model.Mapper
{
    public class LoanData:LoanModel
    {
        public bool Iscompleted { get;set; }
        public string Status { get;set; }
        public decimal OutstandingBalance { get; set; }
        public decimal PayAmount { get; set; }
        public int NumberOfPayments { get; set; }
        public double LoanInterest { get; set; }

        public string LoanTypeDescription { get; set; }
    }
}
