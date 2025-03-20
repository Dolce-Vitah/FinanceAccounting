using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class DeleteOperationCommand: ICommandPattern
    {
        private readonly IOperationFacade operationFacade;
        private readonly long operationId;
        public DeleteOperationCommand(IOperationFacade operationFacade, long operationId)
        {
            this.operationFacade = operationFacade;
            this.operationId = operationId;
        }
        public void Execute()
        {
            operationFacade.Delete(operationId);
        }
    }
}
