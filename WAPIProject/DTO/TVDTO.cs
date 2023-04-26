using Reprository.Core.Models;

namespace WAPIProject.DTO
{
    public class TVDTO
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
        public int NumHDMIInputs { get; set; }
        public int NumUSBPorts { get; set; }
        public int Resolution { get; set; }
        public int RefreshRate { get; set; }
        public bool IsSmartTV { get; set; }
        public bool Is3D { get; set; }
        public bool HasHDR { get; set; }
        public bool HasEthernet { get; set; }
        public bool IsCurved { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasWIFI { get; set; }



        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }


        public int? StoreId { get; set; }
    }
}
