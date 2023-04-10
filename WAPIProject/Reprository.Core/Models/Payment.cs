using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey("store")]
        public int? StoreId { get; set; }
        public Store? store { get; set; }

        [ForeignKey("customer")]
        public string? CustomerId { get; set; }
        public Customer? customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
