using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrdersService.Models;

public partial class MultiServiceDbContext : DbContext
{
    public MultiServiceDbContext()
    {
    }

    public MultiServiceDbContext(DbContextOptions<MultiServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=ENCDAPHYDLT0375; database=multiServiceDb;integrated security=true; Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF43D4A8D7");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.OrderTimeStamp).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
