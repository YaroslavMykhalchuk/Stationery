namespace Stationery
{
    public class Stationery
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int QuantitySold { get; set; }
        public double Prime_cost { get; set; }
        public double Price { get; set; }
        public DateTime Date_sold { get; set; }
        public int? Manager_ID { get; set; }
        public int? Buyer_company_ID { get; set; }
        public int? Type_ID { get; set; }
    }
}
