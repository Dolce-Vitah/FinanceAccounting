using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Models.Abstractions
{
    public interface ICategory
    {
        public long ID { get; }
        public string Name { get; set; }
        public string CategoryType { get; }
    }
}
