using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class MainProduct
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?BrandName { get; set; }
        public string ?Description { get; set; }
        public double Price { get; set; }
        public double? PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public Stars RateValue { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } 

        [ForeignKey("CartItem")]
        public int? CartItemId { get; set; }
        public CartItem? CartItem { get; set; }

        [ForeignKey("Profit")]
        public int? ProfitId { get; set; }
        public Profit? Profit { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public Store? Store { get; set; }

        public List<Review>? Reviews { get; set; }
        public List<Rate>? Rates { get; set; }
        public List<Image>? Images { get; set; }
        // public List<Discount>? Discounts { get; set; }


        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
    }
}
