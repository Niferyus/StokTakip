namespace API.Models
{
    public class MobileProduct
    {
        public string name { get; set; }
        public string barcode { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salePrice { get; set; }
        public int stockAmount { get; set; }
        public string description { get; set; }
    }
}
