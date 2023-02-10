using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreTesting.Models
{
    internal class SeedAccountTypes : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entity)
        {
            entity.HasData(
                new AccountType { AccountTypeID = 1, Name = "PremiumMonthly", TermLengthDays = 30 },
                new AccountType { AccountTypeID = 2, Name = "PremiumYearly", TermLengthDays = 365 },
                new AccountType { AccountTypeID = 3, Name = "Trail", TermLengthDays = 14 }
                ) ;
        }
    }
}