using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class CreateCategoryCommand : ICommandPattern
    {
        private ICategoryFacade facade;
        private readonly IFinanceFactory financeFactory;
        private readonly long categoryId;
        private readonly string name;
        private readonly string type;

        public CreateCategoryCommand(ICategoryFacade facade, IFinanceFactory financeFactory, long categoryId, string name, string type)
        {
            this.facade = facade;
            this.financeFactory = financeFactory;
            this.categoryId = categoryId;
            this.name = name;
            this.type = type;
        }

        public void Execute()
        {
            facade.Add(financeFactory.CreateCategory(categoryId, name, type));
        }
    }
}
