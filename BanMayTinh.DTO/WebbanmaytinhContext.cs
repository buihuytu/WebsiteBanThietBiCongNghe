using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BanMayTinh.DTO;

public partial class WebbanmaytinhContext : DbContext
{
    public WebbanmaytinhContext()
    {
    }

    public WebbanmaytinhContext(DbContextOptions<WebbanmaytinhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblBrand> TblBrands { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblNews> TblNews { get; set; }

    public virtual DbSet<TblNewsCategory> TblNewsCategories { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductImage> TblProductImages { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSlider> TblSliders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-7AIEH3G7;Database=webbanmaytinh;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.ToTable("tblAccount");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Avatar).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(32);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tblAccount_tblRole");
        });

        modelBuilder.Entity<TblBrand>(entity =>
        {
            entity.ToTable("tblBrand");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.MetaDesc).HasMaxLength(500);
            entity.Property(e => e.MetaKey).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Slug).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TblBrands)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tblBrand_tblCategory");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.ToTable("tblCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Icon).HasMaxLength(250);
            entity.Property(e => e.MetaDesc).HasMaxLength(500);
            entity.Property(e => e.MetaKey).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Slug).HasMaxLength(160);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.ToTable("tblContact");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Enquiry).HasColumnType("ntext");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RepliedDate).HasColumnType("datetime");
            entity.Property(e => e.Reply).HasColumnType("ntext");
        });

        modelBuilder.Entity<TblNews>(entity =>
        {
            entity.ToTable("tblNews");

            entity.Property(e => e.Contents).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Image).HasMaxLength(550);
            entity.Property(e => e.MetaDesc).HasMaxLength(500);
            entity.Property(e => e.MetaKey).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Slug).HasMaxLength(160);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdNewCategoryNavigation).WithMany(p => p.TblNews)
                .HasForeignKey(d => d.IdNewCategory)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tblNews_tblNewsCategory");
        });

        modelBuilder.Entity<TblNewsCategory>(entity =>
        {
            entity.ToTable("tblNewsCategory");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Icon).HasMaxLength(250);
            entity.Property(e => e.MetaDesc).HasMaxLength(500);
            entity.Property(e => e.MetaKey).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Slug).HasMaxLength(160);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblOrders");

            entity.ToTable("tblOrder");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExportedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.ReceiverAddress).HasMaxLength(500);
            entity.Property(e => e.ReceiverEmail).HasMaxLength(150);
            entity.Property(e => e.ReceiverName).HasMaxLength(250);
            entity.Property(e => e.ReceiverPhone).HasMaxLength(20);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.ToTable("tblOrderDetail");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblOrderDetail_tblOrder");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.ToTable("tblProduct");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Feature).HasColumnType("ntext");
            entity.Property(e => e.Gift).HasColumnType("ntext");
            entity.Property(e => e.Guarantee).HasColumnType("ntext");
            entity.Property(e => e.Image).HasMaxLength(550);
            entity.Property(e => e.MetaDesc).HasMaxLength(500);
            entity.Property(e => e.MetaKey).HasMaxLength(500);
            entity.Property(e => e.MetaTitle).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.NewPromotion).HasColumnType("ntext");
            entity.Property(e => e.Slug).HasMaxLength(550);
            entity.Property(e => e.Specification).HasColumnType("ntext");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.IdBrand)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tblProduct_tblBrand");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tblProduct_tblCategory");
        });

        modelBuilder.Entity<TblProductImage>(entity =>
        {
            entity.ToTable("tblProductImage");

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TblProductImages)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblProductImage_tblProduct");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.ToTable("tblRole");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblSlider>(entity =>
        {
            entity.ToTable("tblSlider");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
