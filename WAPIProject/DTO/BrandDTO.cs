using System.ComponentModel.DataAnnotations.Schema;

namespace WAPIProject.DTO
{
    public class BrandDTO
    {
        public string Name { get; set; }
        public string? Product_Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
