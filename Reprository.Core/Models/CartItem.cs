using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }  
        public int Product_Quantity { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct? MainProduct { get; set; }


        [ForeignKey("ShoppingCart")]
        public int? ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
