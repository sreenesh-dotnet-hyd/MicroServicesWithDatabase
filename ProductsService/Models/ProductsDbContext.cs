using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductsService.Models;

public partial class ProductsDbContext : DbContext
{
    public ProductsDbContext()
    {
    }

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=ENCDAPHYDLT0375; database=ProductsDb;integrated security=true; Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProdId).HasName("PK__products__319F67F1D157253B");

            entity.ToTable("products");

            entity.Property(e => e.ProdId)
                .ValueGeneratedNever()
                .HasColumnName("prodId");
            entity.Property(e => e.ProdName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("prodName");
            entity.Property(e => e.ProdPrice)
                .HasColumnType("money")
                .HasColumnName("prodPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
