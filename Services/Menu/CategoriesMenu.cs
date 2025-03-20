using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Commands;
using Denisenko_FinanceAccounting.Services.Decorators;
using Denisenko_FinanceAccounting.Services.Facades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Menu
{
    public class CategoriesMenu: IMenu
    {
        public void Show(MenuManager menuManager)
        {
            var factory = menuManager.GetService<IFinanceFactory>();
            var categoryFacade = menuManager.GetService<ICategoryFacade>();
            var logger = menuManager.GetService<ILogger>();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Categories ===");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Remove Category");
                Console.WriteLine("3. Edit Category");
                Console.WriteLine("4. List Categories");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageCategoryCreation(factory, logger, categoryFacade);
                        Console.WriteLine("Category added.");
                        break;
                    case "2":
                        ManageCategoryRemoval(logger, categoryFacade);
                        Console.WriteLine("Category removed.");
                        break;
                    case "3":
                        ManageCategoryEditing(logger, categoryFacade);
                        Console.WriteLine("Category edited.");
                        break;
                    case "4":
                        Console.WriteLine("Categories:");
                        foreach (var c in categoryFacade.GetAll())
                            Console.WriteLine($"- {c}");
                        break;
                    case "5": menuManager.PopMenu(); return;                    
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
       
        private void ManageCategoryCreation(IFinanceFactory factory, ILogger logger, ICategoryFacade facade) 
        {
            Console.Write("Enter category ID: ");
            long id = ManageWrongID(Console.ReadLine());

            Console.Write("Enter category name: ");
            string name = Console.ReadLine();

            Console.Write("Enter category type. E (for Expense) or I (for Income): ");
            string type = ManageWrongType(Console.ReadLine());

            string categoryType = type.ToLower() == "e" ? "Expense" : "Income";

            var command = new CreateCategoryCommand(facade, factory, id, name, categoryType);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
        }

        private void ManageCategoryRemoval(ILogger logger, ICategoryFacade facade)
        {
            Console.Write("Enter category ID to remove: ");
            long removeID = ManageWrongID(Console.ReadLine());

            if (facade.Get(removeID) is null)
            {
                Console.WriteLine("There's no such category");
                return;
            }

            var command = new DeleteCategoryCommand(facade, removeID);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
        }

        private void ManageCategoryEditing(ILogger logger, ICategoryFacade facade)
        {
            Console.WriteLine("Attention! You can only edit a category's name");
            Console.Write("Enter category ID to edit: ");
            long editID = ManageWrongID(Console.ReadLine());

            if (facade.Get(editID) is null)
            {
                Console.WriteLine("There's no such category");
                return; 
            }

            Console.Write("Enter new category name: ");
            string newName = Console.ReadLine();
            
            var command = new EditCategoryCommand(facade, editID, newName);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
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

        private string ManageWrongType(string type)
        {
            while (type.ToLower() != "e" && type.ToLower() != "i")
            {
                Console.Write("There's no such option. Try again: ");
                type = Console.ReadLine();
            }
            return type;
        }
    }
}
