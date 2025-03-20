using Denisenko_FinanceAccounting.Models;
using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Factories
{
    /// <summary>
    /// The concrete factory class that implements the IFinanceFactory interface.
    /// Creates instances of the BankAccount, Category, and Operation classes.
    /// </summary>

    public class FinanceFactory : IFinanceFactory
    {
        public FinanceFactory() { }

        public IBankAccount CreateBankAccount(long id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID cannot be less or equal to zero");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            return new BankAccount(id, name);
        }

        public ICategory CreateCategory(long id, string name, string type)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID cannot be less or equal to zero");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Type cannot be null or empty");
            }

            return new Category(id, name, type);
        }

        public IOperation CreateOperation(long id, double amount, ICategory category,
                                          IBankAccount account, DateTime? date = null, string description = "")
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID cannot be less or equal to zero");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be less or equal to zero");
            }

            if (category == null)
            {
                throw new ArgumentException("Category cannot be null");
            }

            if (account == null)
            {
                throw new ArgumentException("Account cannot be null");
            }

            return new Operation(id, amount, category, account, date, description);
        }
    }
}
