using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public double PercentageOff { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsExpired { get; set; }

        [ForeignKey("MainProduct")]
        public int? MainProductId { get; set; }
        public MainProduct? MainProduct { get; set; }

        [ForeignKey("Admin")]
        public string? AdminId { get; set; }
        public Admin? Admin { get; set; }

        [ForeignKey("Vendor")]
        public string? VendorId { get; set; }
        public Vendor? Vendor { get; set; }
    }
}
