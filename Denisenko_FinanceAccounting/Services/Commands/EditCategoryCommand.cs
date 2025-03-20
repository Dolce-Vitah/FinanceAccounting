using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Commands
{
    public class EditCategoryCommand: ICommandPattern
    {
        private readonly ICategoryFacade categoryFacade;
        private readonly long categoryId;
        private readonly string name;
        public EditCategoryCommand(ICategoryFacade categoryFacade, long categoryId, string name)
        {
            this.categoryFacade = categoryFacade;
            this.categoryId = categoryId;
            this.name = name;
        }
        public void Execute()
        {
            categoryFacade.Edit(categoryId, name);
        }
    }
}
