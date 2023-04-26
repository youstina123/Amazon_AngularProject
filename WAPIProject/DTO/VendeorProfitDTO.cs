namespace WAPIProject.DTO
{
    public class VendeorProfitDTO
    {
        public double Profit { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public double? PriceAfterDiscount { get; set; }
        public DateTime ProfitDate { get; set; }
        public double? Discount { get; set; }
    }
}
