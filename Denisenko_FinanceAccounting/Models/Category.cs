using Denisenko_FinanceAccounting.Models.Abstractions;
using Denisenko_FinanceAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Models
{
    public class Category: ICategory
    {
        public long ID { get; init; }
        public string Name { get; set; }
        public string CategoryType { get; init; }

        public Category(long id, string name, string type)
        {
            ID = id;
            Name = name;
            CategoryType = type;
        }   

        public override string ToString()
        {
            return $"Category \"{Name}\" of type {CategoryType}. ID: {ID}\n";
        }
    }
}
