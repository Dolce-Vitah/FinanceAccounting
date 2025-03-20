using Denisenko_FinanceAccounting.Models;
using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services;
using Denisenko_FinanceAccounting.Services.Abstractions;
using Denisenko_FinanceAccounting.Services.Commands;
using Denisenko_FinanceAccounting.Services.Decorators;
using Denisenko_FinanceAccounting.Services.DI;
using Denisenko_FinanceAccounting.Services.Facades;
using Denisenko_FinanceAccounting.Services.Factories;
using Denisenko_FinanceAccounting.Services.Menu;
using Denisenko_FinanceAccounting.Services.Notifiers;
using Denisenko_FinanceAccounting.Services.Observers;
using Denisenko_FinanceAccounting.Services.Strategies;
using Denisenko_FinanceAccounting.Services.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Xml.Serialization;
using ILogger = Denisenko_FinanceAccounting.Services.Abstractions.ILogger;

namespace Denisenko_FinanceAccounting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DIConfig.Configure();

            var menuManager = new MenuManager(serviceProvider);

            menuManager.Start();
        }
    }
}
