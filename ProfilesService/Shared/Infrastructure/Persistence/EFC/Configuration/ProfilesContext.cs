﻿using System;
using Microsoft.EntityFrameworkCore;
using ProfilesService.Domain.Model.Aggregates;
using ProfilesService.Domain.Model.Entities;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration;

public partial class ProfilesContext : DbContext
{
    public ProfilesContext()
    {
    }

    public ProfilesContext(DbContextOptions<ProfilesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Hotel> Hotels { get; set; }
    public virtual DbSet<Provider> Providers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connection string is already provided via DI in Program.cs
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("customers");
            entity.Property(e => e.Id).HasColumnName("id");

            // Map the audit fields using the correct property names
            entity.Property(e => e.CreatedDate).HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedDate).HasColumnName("UpdatedAt");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.Phone).HasColumnName("phone");

            entity.Property(e => e.State)
                .HasColumnName("state")
                .HasConversion<string>();

            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("hotels");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");

            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .HasColumnName("description");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.OwnersId).HasColumnName("owners_id");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("providers");
            entity.Property(e => e.Id).HasColumnName("id");

            // Map the audit fields using the correct property names
            entity.Property(e => e.CreatedDate).HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedDate).HasColumnName("UpdatedAt");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.Phone).HasColumnName("phone");

            entity.Property(e => e.State)
                .HasColumnName("state")
                .HasConversion<string>();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}