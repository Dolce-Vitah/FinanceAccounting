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
    public class OperationMenu: IMenu
    {
        public void Show(MenuManager menuManager)
        {
            var factory = menuManager.GetService<IFinanceFactory>();
            var operationFacade = menuManager.GetService<IOperationFacade>();
            var logger = menuManager.GetService<ILogger>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Operations ===");
                Console.WriteLine("1. Add Operation");
                Console.WriteLine("2. Remove Operation");
                Console.WriteLine("3. Edit Operation");
                Console.WriteLine("4. List Operations");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageOperationCreation(factory, menuManager, logger, operationFacade);
                        Console.WriteLine("Operation added.");
                        break;
                    case "2":
                        ManageOperationRemoval(logger, operationFacade);
                        Console.WriteLine("Operation removed.");
                        break;
                    case "3":
                        ManageOperationEditing(logger, operationFacade);
                        Console.WriteLine("Operation edited.");
                        break;
                    case "4":
                        Console.WriteLine("Operations:");
                        foreach (var op in operationFacade.GetAll())
                            Console.WriteLine($"- {op}");
                        break;
                    case "5": menuManager.PopMenu(); return;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ManageOperationCreation(IFinanceFactory factory, MenuManager menuManager, ILogger logger, IOperationFacade facade)
        {
            var categoryFacade = menuManager.GetService<ICategoryFacade>();
            var bankAccountFacade = menuManager.GetService<IBankAccountFacade>();

            Console.Write("Enter operation ID: ");
            long id = ManageWrongID(Console.ReadLine());

            Console.Write("Enter amount of operation: ");
            double amount = ManageWrongAmount(Console.ReadLine());

            Console.Write("Enter category's ID of operation: ");
            long categoryID = long.Parse(Console.ReadLine());

            Console.Write("Enter bank account's ID of operation: ");
            long bankAccountID = long.Parse(Console.ReadLine());

            Console.Write("Enter optional date of operation (dd.mm.yyyy): ");
            string stringDate = Console.ReadLine();
            DateTime? date = string.IsNullOrEmpty(stringDate) ? null : ManageWrongDate(stringDate);

            Console.Write("Enter optional description of operation: ");
            string? description = Console.ReadLine();

            var category = categoryFacade.Get(categoryID);
            var bankAccount = bankAccountFacade.Get(bankAccountID);

            if (category is null)
            {
                Console.WriteLine("There's no category with such an ID");
                return;
            }
            if (bankAccount is null)
            {
                Console.WriteLine("There's no account with such an ID");
                return;
            }

            var command = new CreateOperationCommand(facade, factory, id, amount, category, bankAccount, date, description);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
        }

        private void ManageOperationRemoval(ILogger logger, IOperationFacade facade)
        {
            Console.Write("Enter account ID to remove: ");
            long removeID = ManageWrongID(Console.ReadLine());

            var command = new DeleteOperationCommand(facade, removeID);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
        }

        private void ManageOperationEditing(ILogger logger, IOperationFacade facade)
        {
            Console.WriteLine("Attention! You can only edit an operation's description");
            Console.Write("Enter operation ID to edit: ");
            long editID = ManageWrongID(Console.ReadLine());

            Console.Write("Enter new description: ");
            string newDescription = Console.ReadLine();

            var command = new EditOperationCommand(facade, editID, newDescription);
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

        private double ManageWrongAmount(string amount)
        {
            long result;
            while (!long.TryParse(amount, out result))
            {
                Console.Write("Invalid amount. Please enter a valid ID: ");
                amount = Console.ReadLine();
            }
            return result;
        }

        private DateTime? ManageWrongDate(string date)
        {
            DateTime result;
            while (!DateTime.TryParse(date, out result))
            {
                Console.Write("Invalid date. Please enter a valid date: ");
                date = Console.ReadLine();
            }
            return result;
        }
    }
}
