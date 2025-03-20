using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class CreateBankAccountCommand : ICommandPattern
    {
        private IBankAccountFacade facade;
        private readonly IFinanceFactory financeFactory;
        private readonly long accountId;
        private readonly string name;
        public CreateBankAccountCommand(IBankAccountFacade facade, IFinanceFactory financeFactory, long accountId, string name)
        {
            this.facade = facade;
            this.financeFactory = financeFactory;
            this.accountId = accountId;
            this.name = name;
        }
        public void Execute()
        {
            facade.Add(financeFactory.CreateBankAccount(accountId, name));
        }
    }
}
