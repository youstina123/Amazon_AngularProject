using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public enum Specialty
    {
        Mobiles,
        Computers,
        TVandElectronics,
        Fashion,
        Books
    }
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
        public Specialty specialty { get; set; }
        public string ?Description { get; set; }
        public string ?City { get; set; }
        public string ?Country { get; set; }
        public string ?Street { get; set; }
        public Image ?Image { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsConfirmed { get; set; }

        [ForeignKey("vendor")]
        public string? VendorId { get; set; }
        public Vendor? vendor { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
      
        public List<MainProduct>? MainProduct { get; set; }
        public List<Payment>? Payments { get; set; }

    }
}
