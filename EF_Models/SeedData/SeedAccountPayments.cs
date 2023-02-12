using System;
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
            entity.HasData(new AccountPayment { AccountID = 1, PaymentID= 1 , Account = new Account
            {
                AccountID = 1,
                AccountStandingID = 1,
                AccountTypeID = 1,
                City = "Richmond",
                Country = "US",
                Email = "jba123@gmail.com",
                HolderName = "Justin",
                StateOrProvince = "VA",
                StreetAdress = "123 way drive",
                ZipCode = "23225"
            }, Payments= new Payment { PaymentID =1, PaymentDate= DateTime.Now, Note = "test"}
            }) ;


        }
    }
}
