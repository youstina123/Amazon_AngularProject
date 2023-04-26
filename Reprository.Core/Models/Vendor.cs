using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Vendor
    {

        [Key]
        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public Store? Store { get; set; }

        public List<Discount> ?discounts { get; set; }   
        public List<Profit>? profits { get; set; }
        public double TotalProfit { get; set; }=0;
    }
}
