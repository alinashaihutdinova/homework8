using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков.Classes
{
    internal class BankTransaction
    {
        public DateTime TransactionDate { get; }
        public decimal Amount { get; }

        public BankTransaction(decimal amount)
        {
            TransactionDate = DateTime.Now; 
            Amount = amount;
        }
    }
}
