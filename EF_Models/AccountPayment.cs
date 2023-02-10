using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcoreTesting.Models
{
    public class AccountPayment
    {
        public int AccountID { get; set; }
        public int PaymentID { get; set; }

        public Account Account  { get; set; } = null!;
        public Payment Payments  { get; set; } = null!;

    }
}