using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Facades
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly List<ICategory> categories;
        private readonly ICategoryLimitObservable observable;

        public CategoryFacade(ICategoryLimitObservable obs)
        {
            categories = new List<ICategory>();
            observable = obs;
        }

        public void Add(ICategory category)
        {
            categories.Add(category);
        }

        public void Delete(long id)
        {
            var existingCategory = Get(id);
            if (existingCategory != null)
            {
                categories.Remove(existingCategory);
            }
        }

        public void Edit(long id, string newName)
        {
            int index = categories.FindIndex(c => c.ID == id);
            if (index != -1)
            {
                categories[index].Name = newName;
            }
        }

        public void SetLimit(long id, double limit)
        {
            var existingCategory = Get(id);
            if (existingCategory != null)
            {
                observable.SetLimit(existingCategory, limit);
            }
        }

        public void RemoveLimit(long id)
        {
            var existingCategory = Get(id);
            if (existingCategory != null)
            {
                observable.RemoveLimit(existingCategory);
            }
        }

        public ICategory? Get(long id)
        {
            return categories.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<ICategory> GetAll()
        {
            return categories;
        }
    }
}
