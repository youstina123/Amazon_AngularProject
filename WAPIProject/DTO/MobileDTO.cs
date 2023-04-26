using Reprository.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAPIProject.DTO
{
    public class MobileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public Stars RateValue { get; set; }
        public double ScreenSize { get; set; }
        public int RAM { get; set; }
        public int NumSIMCards { get; set; }
        public int BatteryLife { get; set; }
        public int StorageCapacity { get; set; }
        public int Weight { get; set; }
        public bool HasFingerprintScanner { get; set; }
        public int? NumberOfCamera { get; set; }
        public bool HasFrontCamera { get; set; }
        public bool HasBackCamera { get; set; }
        public bool HasNFC { get; set; }
        public bool HasBluetooth { get; set; }
        public bool IsWaterproof { get; set; }
        public string? OperatingSystem { get; set; }
        public ScreenType? Screentype { get; set; }



        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        public int? StoreId { get; set; }
    }
}
