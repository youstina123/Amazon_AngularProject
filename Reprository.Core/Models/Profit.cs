using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Profit
    {
        public int Id { get; set; }
        public double Value { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProfitDate { get; set; }
        public bool IsReturned { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Admin")]
        public string AdminId { get; set; }
        public Admin ?Admin { get; set; }

        [ForeignKey("Vendor")]
        public string VendorId { get; set; }
        public Vendor? Vendor { get; set; }

        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct ?MainProduct { get; set; }

        //[ForeignKey("Store")]
        //public int StoreId { get; set; }
        //public Store? Store { get; set; }
    }
}
