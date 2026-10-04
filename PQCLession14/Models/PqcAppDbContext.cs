using Microsoft.EntityFrameworkCore;

namespace PQCLession14.Models
{
    public class PqcAppDbContext : DbContext
    {
        public PqcAppDbContext(DbContextOptions<PqcAppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Banner>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Điện thoại & Di động", Status = 1, CreatedDate = new DateTime(2026, 1, 10), Image = "category-phone.jpg", Description = "Các dòng điện thoại thông minh cao cấp" },
                new Category { Id = 2, Name = "Laptop & Máy tính", Status = 1, CreatedDate = new DateTime(2026, 1, 12), Image = "category-laptop.jpg", Description = "Laptop văn phòng và đồ họa" },
                new Category { Id = 3, Name = "Phụ kiện công nghệ", Status = 1, CreatedDate = new DateTime(2026, 1, 15), Image = "category-acc.jpg", Description = "Tai nghe, bàn phím, chuột không dây" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 16 Pro Max", Price = 34990000, SalePrice = 32990000, Status = 1, CategoryId = 1, CreatedDate = new DateTime(2026, 2, 1), Image = "iphone16.jpg", Description = "Phiên bản titan tự nhiên cao cấp nhất" },
                new Product { Id = 2, Name = "Samsung Galaxy S25 Ultra", Price = 31990000, SalePrice = 29990000, Status = 1, CategoryId = 1, CreatedDate = new DateTime(2026, 2, 5), Image = "s25ultra.jpg", Description = "Điện thoại tích hợp AI thông minh" },
                new Product { Id = 3, Name = "MacBook Pro M4 14-inch", Price = 42990000, SalePrice = 39990000, Status = 1, CategoryId = 2, CreatedDate = new DateTime(2026, 2, 10), Image = "macbookm4.jpg", Description = "Hiệu năng đột phá cho chuyên gia đồ họa" },
                new Product { Id = 4, Name = "Tai nghe AirPods Pro 2", Price = 5990000, SalePrice = 5290000, Status = 1, CategoryId = 3, CreatedDate = new DateTime(2026, 2, 15), Image = "airpodspro.jpg", Description = "Chống ồn chủ động đỉnh cao" }
            );

            modelBuilder.Entity<Banner>().HasData(
                new Banner { Id = 1, Name = "Khuyến mãi Khai xuân 2026", Status = 1, Prioty = 1, Image = "banner-tet.jpg", Description = "Giảm giá lên đến 50% cho tất cả sản phẩm công nghệ" },
                new Banner { Id = 2, Name = "Sản phẩm công nghệ mới ra mắt", Status = 1, Prioty = 2, Image = "banner-new.jpg", Description = "Trải nghiệm các siêu phẩm công nghệ hàng đầu" }
            );

            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Name = "Đánh giá chi tiết hệ sinh thái Apple 2026", Status = 1, CreatedDate = new DateTime(2026, 3, 1), Image = "blog-apple.jpg", Description = "Tổng hợp trải nghiệm thực tế các dòng sản phẩm mới" },
                new Blog { Id = 2, Name = "Kỷ nguyên Trí tuệ Nhân tạo trên thiết bị di động", Status = 1, CreatedDate = new DateTime(2026, 3, 5), Image = "blog-ai.jpg", Description = "AI đang thay đổi cách chúng ta làm việc hàng ngày ra sao" }
            );
        }
    }
}
