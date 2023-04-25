namespace WAPIProject.DTO
{
    public class VendorTotalProfitDTO
    {
        public List<VendeorProfitDTO> profitList = new List<VendeorProfitDTO>();
        public double TotalProfit { get; set; }
    }
}
