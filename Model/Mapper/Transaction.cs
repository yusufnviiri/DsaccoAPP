using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaccoAPP.Model.Mapper
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string TransactionDate { get; set; } = string.Empty;



    }
}
