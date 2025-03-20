using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class EditOperationCommand: ICommandPattern
    {
        private readonly IOperationFacade operationFacade;
        private readonly long operationId;
        private readonly string newDescription;
        public EditOperationCommand(IOperationFacade operationFacade, long operationId, string newDescription)
        {
            this.operationFacade = operationFacade;
            this.operationId = operationId;
            this.newDescription = newDescription;
        }
        public void Execute()
        {
            operationFacade.Edit(operationId, newDescription);
        }
    }
}
