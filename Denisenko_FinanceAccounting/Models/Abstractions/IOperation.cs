using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Models.Abstractions
{
    public interface IOperation
    {
        public long ID { get; }
        public double Amount { get; }
        public string OperationType { get; }
        public DateTime Date { get; }
        public ICategory CategoryId { get; }
        public IBankAccount BankAccountId { get; }
        public string Description { get; set; }
    }
}
