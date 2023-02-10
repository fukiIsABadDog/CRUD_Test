using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcoreTesting.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string? HolderName { get; set; }
        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public string? StateOrProvince { get; set; }
        public string? Country { get; set; }
        public string? ZipCode{ get; set; }
        public string? Email { get; set; }

        public int AccountTypeID { get; set; }
        public AccountType AccountType { get; set; } = null!;
        public int AccountStandingID { get; set; } //
        public AccountStanding AccountStanding { get; set; } = null!;

        // Made this nullable because its possible to have an account without a payment. ex: trial account
        public ICollection<AccountPayment>? AccountPayments { get; set; } = default;


  


    }
}