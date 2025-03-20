using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Facades
{
    public class OperationFacade : IOperationFacade
    {
        private readonly List<IOperation> operations;
        private readonly ICategoryLimitObservable observable;

        public OperationFacade(ICategoryLimitObservable obs)
        {
            operations = new List<IOperation>();
            observable = obs;
        }

        public void Add(IOperation operation)
        {
            operations.Add(operation);
        }

        public void Delete(long id)
        {
            var existingOperation = operations.FirstOrDefault(o => o.ID == id);
            if (existingOperation != null)
            {
                operations.Remove(existingOperation);
            }
        }

        public void Edit(long id, string newDescription)
        {
            int index = operations.FindIndex(o => o.ID == id);
            if (index != -1)
            {
                operations[index].Description = newDescription;
            }
        }

        public void ProcessOperation(long id)
        {
            var operation = operations.FirstOrDefault(o => o.ID == id);
            if (operation == null)
            {
                return;
            }

            bool isExpense = operation.OperationType == "Expense";
            double addedAmount = isExpense ? -operation.Amount : operation.Amount;
            operation.BankAccountId.UpdateBalance(addedAmount);

            if (isExpense)
            {
                observable.AddExpense(operation);
            }
        }

        public IOperation? Get(long id)
        {
            return operations.FirstOrDefault(o => o.ID == id);
        }

        public IEnumerable<IOperation> GetAll()
        {
            return operations;
        }
    }
}
