using Denisenko_FinanceAccounting.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Abstractions
{
    public interface IBankAccountFacade
    {
        void Add(IBankAccount account);
        void Edit(long id, string newName);
        void Delete(long id);
        IBankAccount? Get(long id);
        IEnumerable<IBankAccount> GetAll();
    }
}
