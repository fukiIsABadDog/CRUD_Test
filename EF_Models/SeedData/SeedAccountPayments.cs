﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreTesting.Models
{
    internal class SeedAccountPayments : IEntityTypeConfiguration<AccountPayment>
    {
        public void Configure(EntityTypeBuilder<AccountPayment> entity)
        {
           
        }
    }
}