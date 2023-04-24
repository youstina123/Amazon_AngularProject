using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public enum ShippingState   
    {
        Ordered,
        Shipped,
        OnWay,
        Delivered,
        Returned,
        Canceled
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        //public int Quantity { get; set; }
        [Column(TypeName = "date")] 
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReturned { get; set; }
        public ShippingState shippingState { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }

        //public List<MainProduct>? Products { get; set; }
    }
}
