using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Models
{
    public class BankAccount : IBankAccount
    {
        public long ID { get; init; }
        public string Name { get; set; }
        public double Balance { get; private set; }

        public BankAccount(long id, string name)
        {
            ID = id;
            Name = name;
            Balance = 0;
        }

        public void UpdateBalance(double amount)
        {
            Balance += amount;
        }

        public override string ToString()
        {
            return $"Bank account \"{Name}\" with balance {Balance}. ID: {ID}\n";
        }

    }
}
