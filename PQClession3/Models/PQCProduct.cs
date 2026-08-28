namespace PQClession3.Models
{
    public class PQCProduct
    {
        public string PQCProductId { get; set; } = string.Empty;
        public string PQCProductName { get; set; } = string.Empty;
        public int PQCYearRelease { get; set; }
        public decimal PQCPrice { get; set; }
    }
}
