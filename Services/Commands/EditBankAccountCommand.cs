using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class EditBankAccountCommand: ICommandPattern
    {
        private readonly IBankAccountFacade bankAccountFacade;
        private readonly long accountId;
        private readonly string newName;

        public EditBankAccountCommand(IBankAccountFacade bankAccountFacade, long accountId, string newName)
        {
            this.bankAccountFacade = bankAccountFacade;
            this.accountId = accountId;
            this.newName = newName;
        }

        public void Execute()
        {
            bankAccountFacade.Edit(accountId, newName);
        }
    }
}
