using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class DeleteBankAccountCommand: ICommandPattern
    {
        private readonly IBankAccountFacade bankAccountFacade;
        private readonly long accountId;
        public DeleteBankAccountCommand(IBankAccountFacade bankAccountFacade, long accountId)
        {
            this.bankAccountFacade = bankAccountFacade;
            this.accountId = accountId;
        }
        public void Execute()
        {
            bankAccountFacade.Delete(accountId);
        }
    }
}
