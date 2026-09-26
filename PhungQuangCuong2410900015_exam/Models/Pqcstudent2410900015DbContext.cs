using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhungQuangCuong2410900015_exam.Models;

public partial class Pqcstudent2410900015DbContext : DbContext
{
    public Pqcstudent2410900015DbContext()
    {
    }

    public Pqcstudent2410900015DbContext(DbContextOptions<Pqcstudent2410900015DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PqcStudent> PqcStudents { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=CUOG-DZ\\SQLEXPRESS;Database=PQCStudent_2410900015_Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PqcStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PqcStude__3214EC07FB7C4E99");

            entity.ToTable("PqcStudent");

            entity.Property(e => e.PqcActive).HasDefaultValue(true);
            entity.Property(e => e.PqcEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PqcName).HasMaxLength(100);
            entity.Property(e => e.PqcPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
