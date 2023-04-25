using Reprository.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAPIProject.DTO
{
    public class CardItemDTO
    {

       
        public int Product_Quantity { get; set; }
        public string? customerId { get; set; }
        public int MainProductId { get; set; }          
        public int? ShoppingCartId { get; set; }
        
    }
}
