namespace PQCLession13.Models
{
    public static class PqcProductData
    {
        public static List<PqcProduct> Products { get; } = new List<PqcProduct>
        {
            new PqcProduct
            {
                Id = 1,
                PqcName = "Laptop Dell XPS 15",
                PqcPrice = 32500000,
                PqcCategory = "Laptop",
                PqcDescription = "Laptop cao cấp màn hình OLED 4K, CPU Intel Core i9, RAM 32GB",
                PqcImageUrl = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?w=500&q=80",
                PqcStatus = true
            },
            new PqcProduct
            {
                Id = 2,
                PqcName = "iPhone 16 Pro Max",
                PqcPrice = 34990000,
                PqcCategory = "Điện thoại",
                PqcDescription = "Titan sa mạc, Camera 48MP Zoom 5x quang học, chip A18 Pro",
                PqcImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=500&q=80",
                PqcStatus = true
            },
            new PqcProduct
            {
                Id = 3,
                PqcName = "Bàn phím cơ PQC Mechanical Pro",
                PqcPrice = 1850000,
                PqcCategory = "Phụ kiện",
                PqcDescription = "Switch Custom RGB, kết nối 3 chế độ không dây, gõ siêu mượt",
                PqcImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=500&q=80",
                PqcStatus = true
            },
            new PqcProduct
            {
                Id = 4,
                PqcName = "Tai nghe Sony WH-1000XM5",
                PqcPrice = 7490000,
                PqcCategory = "Âm thanh",
                PqcDescription = "Chống ồn chủ động đỉnh cao, thời lượng pin 30 giờ, Hi-Res Audio",
                PqcImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&q=80",
                PqcStatus = true
            },
            new PqcProduct
            {
                Id = 5,
                PqcName = "Màn hình Dell UltraSharp 27 Inch 4K",
                PqcPrice = 12900000,
                PqcCategory = "Màn hình",
                PqcDescription = "Độ phủ màu 100% sRGB, kết nối Type-C 90W sạc nhanh",
                PqcImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&q=80",
                PqcStatus = false
            },
            new PqcProduct
            {
                Id = 6,
                PqcName = "Chuột Logitech MX Master 3S",
                PqcPrice = 2150000,
                PqcCategory = "Phụ kiện",
                PqcDescription = "Cảm biến 8K DPI trên mọi bề mặt, nút bấm yên tĩnh Quiet Clicks",
                PqcImageUrl = "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=500&q=80",
                PqcStatus = true
            }
        };
    }
}
