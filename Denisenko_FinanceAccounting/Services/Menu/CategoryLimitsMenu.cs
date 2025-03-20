using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Facades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Menu
{
    public class CategoryLimitsMenu : IMenu
    {
        public void Show(MenuManager menuManager)
        {
            var categoryFacade = menuManager.GetService<ICategoryFacade>();
            var operationFacade = menuManager.GetService<IOperationFacade>();

            var observable = menuManager.GetService<ICategoryLimitObservable>();
            var observer = menuManager.GetService<ICategoryLimitObserver>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Set Category Limit ===");
                Console.WriteLine("1. Set Limit for Category");
                Console.WriteLine("2. Remove Limit from Category");
                Console.WriteLine("3. Back");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageCategoryLimitSet(categoryFacade);
                        Console.WriteLine("The limit has been set.");
                        break;
                    case "2":
                        ManageCategoryLimitRemove(categoryFacade);
                        Console.WriteLine($"Limit removed.");
                        break;
                    case "3": menuManager.PopMenu(); return;                    
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ManageCategoryLimitSet(ICategoryFacade categoryFacade)
        {
            Console.Write("Enter category ID: ");
            long categoryId = ManageWrongID(Console.ReadLine());
            var category = categoryFacade.Get(categoryId);

            if (category is null)
            {
                Console.WriteLine("There's no such category");
                return;
            }

            Console.Write("Enter spending limit: ");
            double limit = Math.Abs(ManageWrongLimit(Console.ReadLine()));

            categoryFacade.SetLimit(categoryId, limit);
        }

        private void ManageCategoryLimitRemove(ICategoryFacade categoryFacade)
        {
            Console.Write("Enter category ID: ");
            long categoryId = ManageWrongID(Console.ReadLine());
            var category = categoryFacade.Get(categoryId);

            if (category is null)
            {
                Console.WriteLine("There's no such category");
                return;
            }

            categoryFacade.RemoveLimit(categoryId);
        }

        private long ManageWrongID(string id)
        {
            long result;
            while (!long.TryParse(id, out result))
            {
                Console.Write("Invalid ID. Please enter a valid ID: ");
                id = Console.ReadLine();
            }
            return result;
        }

        private double ManageWrongLimit(string limit)
        {
            long result;
            while (!long.TryParse(limit, out result))
            {
                Console.Write("Invalid limit. Please enter a valid ID: ");
                limit = Console.ReadLine();
            }
            return result;
        }
    }
}
