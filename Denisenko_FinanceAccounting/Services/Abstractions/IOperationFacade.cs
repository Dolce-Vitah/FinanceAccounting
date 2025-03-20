using Denisenko_FinanceAccounting.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Abstractions
{
    public interface IOperationFacade
    {
        void Add(IOperation account);
        void Edit(long id, string newDescription);
        void Delete(long id);
        void ProcessOperation(long id);
        IOperation? Get(long id);
        IEnumerable<IOperation> GetAll();
    }
}
