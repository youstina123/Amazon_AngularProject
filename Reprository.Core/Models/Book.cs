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
    public class Book
    {
        [Key]
        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }
        public double Weight { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublicationYear { get; set; }
        public int PageCount { get; set; }
        public string? AuthorName { get; set; }
        public string? BookDescription { get; set; }
        public string? Publisher { get; set; }       
        public string? Language { get; set; }        
        public string? Edition { get; set; }       
        public string? Type { get; set; }
        public string? Awards { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
