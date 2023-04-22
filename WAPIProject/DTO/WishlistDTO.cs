using Reprository.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAPIProject.DTO
{
    public class WishlistDTO
    {
        public int Product_Quantity { get; set; }
        public int? MainProductId { get; set; }
        public string? CustomerId { get; set; }
    }
}
