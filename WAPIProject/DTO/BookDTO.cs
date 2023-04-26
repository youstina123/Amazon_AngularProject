using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reprository.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAPIProject.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public Stars RateValue { get; set; }
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



        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        public int? StoreId { get; set; }
    }
}
