using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class CreateOperationCommand: ICommandPattern
    {
        private IOperationFacade facade;
        private readonly IFinanceFactory factory;
        private readonly long operationId;
        private readonly IBankAccount bankAccount;
        private readonly ICategory category;
        private readonly double amount;
        private readonly DateTime? date;
        private readonly string description;
        public CreateOperationCommand(IOperationFacade facade, IFinanceFactory factory, long operationId, double amount, ICategory category,
                                      IBankAccount bankAccount, DateTime? date = null, string description = "")
        {
            this.facade = facade;
            this.factory = factory;
            this.operationId = operationId;
            this.bankAccount = bankAccount;
            this.category = category;
            this.amount = amount;
            this.date = date;
            this.description = description;
        }
        public void Execute()
        {
            var operation = factory.CreateOperation(operationId, amount, category, bankAccount, date, description);
            facade.Add(operation);
            facade.ProcessOperation(operationId);
        }
    }
}
