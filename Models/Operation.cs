using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Models
{
    public class Operation: IOperation
    {
        public long ID { get; init; }
        public string OperationType { get; init; }
        public double Amount { get; init; }
        public DateTime Date { get; init; }
        public ICategory CategoryId { get; init; }
        public IBankAccount BankAccountId { get; init; }
        public string Description { get; set; }

        public Operation(long id, double amount, ICategory category, 
                         IBankAccount bankAccount, DateTime? date = null, string description = "")
        {
            ID = id;
            OperationType = category.CategoryType;
            Amount = amount;
            Date = date ?? DateTime.Today;
            CategoryId = category;
            BankAccountId = bankAccount;
            Description = description;
        }

        public override string ToString()
        {
            return $"Operation of type {OperationType} with amount {Amount}. ID: {ID}, date of creation: {Date}\n" +
                   $"Description: {(string.IsNullOrEmpty(Description) ? "none" : Description)}\n";
        }
    }
}
