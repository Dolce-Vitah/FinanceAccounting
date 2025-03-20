using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Models.Abstractions
{
    public interface IBankAccount
    {
        public long ID { get; }
        public string Name { get; set; }
        public double Balance { get; }

        public void UpdateBalance(double amount);
    }
}
