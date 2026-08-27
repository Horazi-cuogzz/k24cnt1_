namespace PQClession2demo.Models
{
    public class PQCProduct
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int YearRelease { get; set; }
        public decimal Price { get; set; }
    }
}
