using Denisenko_FinanceAccounting.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = Denisenko_FinanceAccounting.Services.Abstractions.ILogger;

namespace Denisenko_FinanceAccounting.Services.Decorators
{
    public class LoggerDecorator : ICommandPattern
    {
        private readonly ICommandPattern command;
        private readonly ILogger logger;
        public LoggerDecorator(ICommandPattern command, ILogger logger)
        {
            this.command = command;
            this.logger = logger;
        }

        public void Execute()
        {
            logger.Log($"Started executing at {DateTime.Now}: {command.GetType().Name}\n");
            command.Execute();
            logger.Log($"Finished executing at {DateTime.Now}: {command.GetType().Name}\n");
        }
    }
}
