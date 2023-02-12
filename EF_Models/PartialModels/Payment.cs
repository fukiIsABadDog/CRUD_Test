using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcoreTesting.Models
{
    public partial class Payment
    {
        

        [NotMapped]
        public decimal PaymentTest { get => AccountType.Costs().Select(x => x.Value).First(); } // test prop
    }
}
