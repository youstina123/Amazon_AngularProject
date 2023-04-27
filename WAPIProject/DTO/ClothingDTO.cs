using Reprository.Core.Models;

namespace WAPIProject.DTO
{
    public class ClothingDTO
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? PriceAfterDiscount { get; set; }
        public List<IFormFile> Images { get; set; }

        public int Quantity { get; set; }
        public Stars RateValue { get; set; }
        public int MainProductId { get; set; }

        public string? Size { get; set; }
        public string? Gender { get; set; }
        public string? Style { get; set; }
        public string? Season { get; set; }
        public string? ManufacturerCountry { get; set; }
        public string? SleeveStyle { get; set; }


        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        public int? StoreId { get; set; }
    }
}
