using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[]? ImageSource { get; set; }

        [ForeignKey("product")]
        public int? ProductId { get; set; }
        public MainProduct? product { get; set; }
        public bool IsDeleted { get; set; }

    }
}
