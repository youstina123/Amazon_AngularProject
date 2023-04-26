using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Product_Name { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public virtual List<MainProduct>? MainProducts { get; set; }
       

    }
}
