using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class DeleteCategoryCommand: ICommandPattern
    {
        private readonly ICategoryFacade categoryFacade;
        private readonly long categoryId;
        public DeleteCategoryCommand(ICategoryFacade categoryFacade, long categoryId)
        {
            this.categoryFacade = categoryFacade;
            this.categoryId = categoryId;
        }
        public void Execute()
        {
            categoryFacade.Delete(categoryId);
        }
    }
}
