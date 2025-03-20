using Denisenko_FinanceAccounting.Models;
using Denisenko_FinanceAccounting.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Abstractions
{
    public interface IFinanceFactory
    {
        IBankAccount CreateBankAccount(long id, string name);

        ICategory CreateCategory(long id, string name, string type);

        IOperation CreateOperation(long id, double amount, ICategory category, 
                                   IBankAccount account, DateTime? date = null, string description = "");
    }
}
