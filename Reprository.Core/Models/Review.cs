using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("MainProduct")]
        public int? MainProductId { get; set; }
        public MainProduct? MainProduct { get; set; }

        [ForeignKey("customer")]
        public string? CustomerId { get; set; }
        public Customer? customer { get; set; }

    }
}
