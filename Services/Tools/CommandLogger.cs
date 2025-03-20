using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Tools
{
    public class CommandLogger : ILogger
    {
        private readonly string filePath;

        public CommandLogger(string filePath = "..\\..\\..\\log.txt")
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                File.WriteAllText(filePath, "");
            }

            this.filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(filePath, message);
        }
    }
}
