using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcoreTesting.Models
{
    public class AccountType
    {
        public int AccountTypeID { get; set; }
        public string? Name { get; set; }
        public int TermLengthDays { get; set; }
    }
}
