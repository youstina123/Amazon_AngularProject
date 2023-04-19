using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Clothing
    {
        [Key]
        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }

        public string? Size { get; set; }
        public string? Gender { get; set; }
        public string? Style { get; set; }
        public string? Season { get; set; }
        public string? ManufacturerCountry { get; set; }
        public string? SleeveStyle { get; set; }
      
    }
}
