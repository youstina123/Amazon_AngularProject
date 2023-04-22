using Reprository.Core.Models;

namespace WAPIProject.DTO
{
    public class ComputerDTO
    {
        public int MainProductId { get; set; }

        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public Stars RateValue { get; set; }
        public double Weight { get; set; }
        public int RAM { get; set; }
        public int StorageCapacity { get; set; }
        public int USBPorts { get; set; }
        public int HDMIOutputs { get; set; }
        public int WarrantyPeriod { get; set; }
        public string? Model { get; set; }
        public string? Processor { get; set; }
        public string? GraphicsCard { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Material { get; set; }
        public string? CountryOfOrigin { get; set; }
        public bool HasTouchscreen { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasMouse { get; set; }

        public bool IsDeletede { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? CartItemId { get; set; }

        public int? ProfitId { get; set; }

        public int? StoreId { get; set; }
    }
}
