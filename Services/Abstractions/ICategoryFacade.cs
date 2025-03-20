using Denisenko_FinanceAccounting.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Abstractions
{
    public interface ICategoryFacade
    {
        void Add(ICategory account);
        void Edit(long id, string newName);
        void Delete(long id);
        void SetLimit(long id, double limit);
        void RemoveLimit(long id);
        ICategory? Get(long id);
        IEnumerable<ICategory> GetAll();
    }
}
