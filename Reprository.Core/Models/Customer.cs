using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Reprository.Core.Models
{
    public class Customer
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ?ApplicationUserId { get; set; }
        public ApplicationUser ?ApplicationUser { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("Wishlist")]
        public int? WishlistId { get; set; }
        public Wishlist ?Wishlist { get; set; }

        [ForeignKey("ShoppingCart")]
        public int? ShoppingCartId { get; set; }
        public ShoppingCart ?ShoppingCart { get; set; }

        public  List<Payment>? Payments { get; set; }
        public  List<Review>? Reviews { get; set; }
        public  List<Order>? Orders { get; set; }
        public List<Rate>? Rates { get; set; }

    }
}
