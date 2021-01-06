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

        public virtual DbSet<ChiTietLichSu> ChiTietLichSus { get; set; }
        public virtual DbSet<Dmanh> Dmanhs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<LichSu> LichSus { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-BJJNCTC;Database=QLHOPDONG;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietLichSu>(entity =>
            {
                entity.ToTable("ChiTietLichSu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Dvt).HasMaxLength(50);

                entity.Property(e => e.HangMuc).HasMaxLength(50);

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.LichSu)
                    .WithMany(p => p.ChiTietLichSus)
                    .HasForeignKey(d => d.LichSuId)
                    .HasConstraintName("FK_ChiTietLichSu_LichSu");
            });

            modelBuilder.Entity<Dmanh>(entity =>
            {
                entity.ToTable("DMAnh");

                entity.Property(e => e.FileUrl).HasMaxLength(250);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenA).HasMaxLength(200);

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DaiDien).HasMaxLength(250);

                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.DienThoai).HasMaxLength(100);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .HasColumnName("MaKH");

                entity.Property(e => e.Mst).HasMaxLength(50);
            });

            modelBuilder.Entity<LichSu>(entity =>
            {
                entity.ToTable("LichSu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenA).HasMaxLength(50);

                entity.Property(e => e.ChucVu).HasMaxLength(50);

                entity.Property(e => e.DaiDien).HasMaxLength(150);

                entity.Property(e => e.DiaChi).HasMaxLength(120);

                entity.Property(e => e.DiaDienTrinhDien).HasMaxLength(250);

                entity.Property(e => e.DienThoai).HasMaxLength(15);

                entity.Property(e => e.GiaTriHopDong).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Mst).HasMaxLength(20);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianLapDat).HasMaxLength(80);

                entity.Property(e => e.ThoiGianThucHien).HasColumnType("date");

                entity.Property(e => e.Tong).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VAT");
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
