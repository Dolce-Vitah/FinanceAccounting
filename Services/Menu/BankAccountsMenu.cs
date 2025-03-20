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
    public class BankAccountMenu : IMenu
    {
        public void Show(MenuManager menuManager)
        {
            var factory = menuManager.GetService<IFinanceFactory>();
            var accountFacade = menuManager.GetService<IBankAccountFacade>();
            var logger = menuManager.GetService<ILogger>();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Accounts ===");
                Console.WriteLine("1. Add Account");
                Console.WriteLine("2. Remove Account");
                Console.WriteLine("3. Edit Account");
                Console.WriteLine("4. List Accounts");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageAccountCreation(factory, logger, accountFacade);
                        Console.WriteLine("Account added.");
                        break;
                    case "2":
                        ManageAccountRemoval(logger, accountFacade);
                        Console.WriteLine("Account removed.");
                        break;
                    case "3":
                        ManageAccountEditing(logger, accountFacade);
                        Console.WriteLine("Account edited.");
                        break;
                    case "4":
                        Console.WriteLine("Accounts:");
                        foreach (var acc in accountFacade.GetAll())
                            Console.WriteLine($"- {acc}");
                        break;
                    case "5": menuManager.PopMenu(); return;                   
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ManageAccountCreation(IFinanceFactory factory, ILogger logger, IBankAccountFacade facade)
        {
            Console.Write("Enter account ID: ");
            long id = ManageWrongID(Console.ReadLine());

            Console.Write("Enter account name: ");
            string name = Console.ReadLine();

            var command = new CreateBankAccountCommand(facade, factory, id, name);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
        }

        private void ManageAccountRemoval(ILogger logger, IBankAccountFacade facade)
        {
            Console.Write("Enter account ID to remove: ");
            long removeID = ManageWrongID(Console.ReadLine());

            if (facade.Get(removeID) is null)
            {
                Console.WriteLine("There's no such account");
                return;
            }

            var command = new DeleteBankAccountCommand(facade, removeID);
            var loggerCommand = new LoggerDecorator(command, logger);

            loggerCommand.Execute();
        }

        private void ManageAccountEditing(ILogger logger, IBankAccountFacade facade)
        {
            Console.WriteLine("Attention! You can only edit an account's name");
            Console.Write("Enter account ID to edit: ");
            long editID = ManageWrongID(Console.ReadLine());

            if (facade.Get(editID) is null)
            {
                Console.WriteLine("There's no such account");
                return;
            }

            Console.Write("Enter a new name for the account: ");
            string newName = Console.ReadLine();

            var command = new EditBankAccountCommand(facade, editID, newName);
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
    }
}
