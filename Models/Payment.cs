using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalBrands.Models
{
    public class Payment
    {
        [Key, ForeignKey("Order")]
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Method { get; set; }
      
        public virtual Order Order { get; set; }
    }
}
