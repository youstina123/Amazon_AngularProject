using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public enum Stars
    {
        oneStar = 1,
        twoStar = 2,    
        threeStar=3,  
        fourStar= 4,   
        fiveStar= 5,
    }
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        public Stars stars { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("MainProduct")]
        public int? MainProductId { get; set; }
        public MainProduct? MainProduct { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
