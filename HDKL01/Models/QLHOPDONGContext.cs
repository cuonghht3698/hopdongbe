using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HDKL01.Models
{
    public partial class QLHOPDONGContext : DbContext
    {
        public QLHOPDONGContext()
        {
        }

        public QLHOPDONGContext(DbContextOptions<QLHOPDONGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-3NLG68E\\MSS15;Database=QLHOPDONG;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenA).HasMaxLength(200);

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DaiDien).HasMaxLength(250);

                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.DienThoai).HasMaxLength(100);

                entity.Property(e => e.Mst).HasMaxLength(50);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("SANPHAM");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Dvt).HasMaxLength(200);

                entity.Property(e => e.HangMuc).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
