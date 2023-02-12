using EFcoreTesting.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcoreTesting.Models
{
    public partial class AccountType
    {
        public static Dictionary<String, decimal> Costs() 
        {
            var costs = new Dictionary<String, decimal>();
            costs.Add("PrimiumMonthly", (decimal)(12.99));
            return costs;
        }
        
    }

 
}
