using Microsoft.EntityFrameworkCore;

namespace PQCLession12.Models
{
    public class PqcAppDbContext : DbContext
    {
        public PqcAppDbContext(DbContextOptions<PqcAppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<PqcCategory> PqcCategories { get; set; } = null!;
        public virtual DbSet<PqcProduct> PqcProducts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Quan hệ 1 - N giữa PqcCategory và PqcProduct
            modelBuilder.Entity<PqcProduct>()
                .HasOne(p => p.PqcCategory)
                .WithMany(c => c.PqcProducts)
                .HasForeignKey(p => p.PqcCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
