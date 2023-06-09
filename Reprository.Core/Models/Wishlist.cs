﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        public int Product_Quantity { get; set; }

        [ForeignKey("MainProduct")]
        public int? MainProductId { get; set; }
        public MainProduct? MainProduct { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        //public virtual List<CartItem>? CartItems { get; set; }
    }
}
