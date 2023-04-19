using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public Store? Store { get; set; }

     /*   [ForeignKey("MainProduct")]
        public int? MainProductId { get; set; }
        public MainProduct? MainProduct { get; set; }*/

        public List<MainProduct>? MainProducts { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}
