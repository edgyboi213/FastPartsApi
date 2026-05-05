using System;
using System.Collections.Generic;
using FastPartsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FastPartsApi.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Oemnumber> Oemnumbers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderpart> Orderparts { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Profilephoto> Profilephotos { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(30);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.IdCart).HasName("PRIMARY");

            entity.ToTable("cart");

            entity.HasIndex(e => e.IdPart, "fk_Cart_Part1_idx");

            entity.HasIndex(e => e.IdUser, "fk_Cart_User1_idx");

            entity.HasOne(d => d.IdPartNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cart_Part1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cart_User1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.IdMedia).HasName("PRIMARY");

            entity.ToTable("media");

            entity.Property(e => e.Content).HasMaxLength(1000);
        });

        modelBuilder.Entity<Oemnumber>(entity =>
        {
            entity.HasKey(e => e.IdOemNumber).HasName("PRIMARY");

            entity.ToTable("oemnumber");

            entity.Property(e => e.Number).HasMaxLength(45);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.IdUser, "fk_Order_User_idx");

            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_User");
        });

        modelBuilder.Entity<Orderpart>(entity =>
        {
            entity.HasKey(e => new { e.OrderIdOrder, e.PartIdPart }).HasName("PRIMARY");

            entity.ToTable("orderpart");

            entity.HasIndex(e => e.OrderIdOrder, "fk_Order_has_Part_Order1_idx");

            entity.HasIndex(e => e.PartIdPart, "fk_Order_has_Part_Part1_idx");

            entity.Property(e => e.OrderIdOrder).HasColumnName("Order_IdOrder");
            entity.Property(e => e.PartIdPart).HasColumnName("Part_IdPart");

            entity.HasOne(d => d.OrderIdOrderNavigation).WithMany(p => p.Orderparts)
                .HasForeignKey(d => d.OrderIdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_has_Part_Order1");

            entity.HasOne(d => d.PartIdPartNavigation).WithMany(p => p.Orderparts)
                .HasForeignKey(d => d.PartIdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_has_Part_Part1");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.IdPart).HasName("PRIMARY");

            entity.ToTable("part");

            entity.HasIndex(e => e.IdMedia, "fk_Part_Media1_idx");

            entity.HasIndex(e => e.IdCategory, "fk_part_Category1_idx");

            entity.HasIndex(e => e.IdOemNumber, "fk_part_OemNumber1_idx");

            entity.Property(e => e.Description).HasMaxLength(5000);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Volume).HasMaxLength(45);
            entity.Property(e => e.Weight).HasMaxLength(45);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Parts)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_part_Category1");

            entity.HasOne(d => d.IdMediaNavigation).WithMany(p => p.Parts)
                .HasForeignKey(d => d.IdMedia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Part_Media1");

            entity.HasOne(d => d.IdOemNumberNavigation).WithMany(p => p.Parts)
                .HasForeignKey(d => d.IdOemNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_part_OemNumber1");
        });

        modelBuilder.Entity<Profilephoto>(entity =>
        {
            entity.HasKey(e => e.IdProfilePhoto).HasName("PRIMARY");

            entity.ToTable("profilephoto");

            entity.Property(e => e.Photo).HasMaxLength(100);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PRIMARY");

            entity.ToTable("review");

            entity.HasIndex(e => e.IdPart, "fk_Review_part1_idx");

            entity.HasIndex(e => e.IdUser, "fk_Review_user1_idx");

            entity.Property(e => e.ReviewText).HasMaxLength(5000);

            entity.HasOne(d => d.IdPartNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Review_part1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Review_user1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.IdProfilePhoto, "fk_User_ProfilePhoto1_idx");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(30);

            entity.HasOne(d => d.IdProfilePhotoNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdProfilePhoto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_ProfilePhoto1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
