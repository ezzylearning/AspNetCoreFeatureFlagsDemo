using System;
using System.Collections.Generic;
using AspNetCoreFeatureFlagsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreFeatureFlagsDemo.Data;

public partial class SportsDbContext : DbContext
{
    public SportsDbContext(DbContextOptions<SportsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stadium> Stadiums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stadium>(entity =>
        {
            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.AddressLine3).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
