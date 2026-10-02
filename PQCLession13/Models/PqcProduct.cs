namespace PQCLession13.Models
{
    public class PqcProduct
    {
        public int Id { get; set; }
        public string PqcName { get; set; } = string.Empty;
        public decimal PqcPrice { get; set; }
        public string PqcCategory { get; set; } = string.Empty;
        public string PqcDescription { get; set; } = string.Empty;
        public string PqcImageUrl { get; set; } = string.Empty;
        public bool PqcStatus { get; set; } = true;
    }
}
