using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reprository.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAPIProject.DTO
{
    public class DiscountDTO
    {
        public double PercentageOff { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MainProductId { get; set; }
        public string? VendorId { get; set; }
    }
}
