using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class ShoppingCart
    {

        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public virtual List<CartItem>? CartItems { get; set; }
    }
}
