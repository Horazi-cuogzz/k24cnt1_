using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PqcLession10EFDb.Models;

public partial class Pqck24cnt1lession10EfdbContext : DbContext
{
    public Pqck24cnt1lession10EfdbContext()
    {
    }

    public Pqck24cnt1lession10EfdbContext(DbContextOptions<Pqck24cnt1lession10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PqcMember> PqcMembers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=CUOG-DZ\\SQLEXPRESS;Database=PQCK24CNT1Lession10EFDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PqcMember>(entity =>
        {
            entity.ToTable("PqcMember");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PqcEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PqcFullName).HasMaxLength(50);
            entity.Property(e => e.PqcPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PqcPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PqcUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
