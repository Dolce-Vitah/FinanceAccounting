using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Facades
{
    public class BankAccountFacade : IBankAccountFacade
    {
        private List<IBankAccount> accounts;

        public BankAccountFacade()
        {
            accounts = new List<IBankAccount>();
        }

        public void Add(IBankAccount account)
        {
            accounts.Add(account);
        }

        public void Delete(long id)
        {
            var existingAccount = accounts.FirstOrDefault(a => a.ID == id);
            if (existingAccount != null)
            {
                accounts.Remove(existingAccount);
            }
        }

        public void Edit(long id, string newName)
        {
            int index = accounts.FindIndex(a => a.ID == id);
            if (index != -1)
            {
                accounts[index].Name = newName;
            }
        }

        public IBankAccount? Get(long id)
        {
            return accounts.FirstOrDefault(a => a.ID == id);
        }

        public IEnumerable<IBankAccount> GetAll()
        {
            return accounts;
        }
    }
}
