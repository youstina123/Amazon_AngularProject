using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public enum PaymentMethod
    {
        Cash,
        VISA,
        Paypal
    }
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        [ForeignKey("store")]
        public int? StoreId { get; set; }
        public Store? store { get; set; }

        [ForeignKey("customer")]
        public string? CustomerId { get; set; }
        public Customer? customer { get; set; }

        [ForeignKey("order")]
        public int? OrderId { get; set; }
        public Order? order { get; set; }
    }
}
