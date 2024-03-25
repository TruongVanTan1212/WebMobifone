using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WeSimMobifone.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chucvu> Chucvu { get; set; }
        public virtual DbSet<Cuahang> Cuahang { get; set; }
        public virtual DbSet<Danhmuc> Danhmuc { get; set; }
        public virtual DbSet<Diachi> Diachi { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Huongdan> Huongdan { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loaitb> Loaitb { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Thuebao> Thuebao { get; set; }
        public virtual DbSet<Tintuc> Tintuc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRUONGVANTAN\\SQLEXPRESS;Database=WebSimbMobifone;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__CHUCVU__27258E760A90F187");

                entity.Property(e => e.HeSo).HasDefaultValueSql("((1.0))");
            });

            modelBuilder.Entity<Cuahang>(entity =>
            {
                entity.HasKey(e => e.MaCh)
                    .HasName("PK__CUAHANG__27258E00A6FC429C");

                entity.Property(e => e.DienThoai).IsUnicode(false);
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DANHMUC__2725866E4D38EA83");
            });

            modelBuilder.Entity<Diachi>(entity =>
            {
                entity.HasKey(e => e.MaDc)
                    .HasName("PK__DIACHI__2725866413E61BCE");

                entity.Property(e => e.MacDinh).HasDefaultValueSql("((1))");

                entity.Property(e => e.PhuongXa).IsUnicode(false);

                entity.Property(e => e.QuanHuyen).IsUnicode(false);

                entity.Property(e => e.TinhThanh).IsUnicode(false);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Diachi)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIACHI__MaKH__4AB81AF0");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HOADON__2725A6E04A44D4E6");

                entity.Property(e => e.Ngay).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TongTien).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MaKH__5165187F");

                entity.HasOne(d => d.MaTbNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.MaTb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MaTB__4E88ABD4");
            });

            modelBuilder.Entity<Huongdan>(entity =>
            {
                entity.HasKey(e => e.MaHdan)
                    .HasName("PK__HUONGDAN__1418FD7DA043E111");

                entity.Property(e => e.NgayDang).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHACHHAN__2725CF1E7F7646D8");

                entity.Property(e => e.Cccd).IsUnicode(false);

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.HinhS).IsUnicode(false);

                entity.Property(e => e.HinhT).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.SlthueB).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Loaitb>(entity =>
            {
                entity.HasKey(e => e.MaLtb)
                    .HasName("PK__LOAITB__3B98372DA0158673");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NHANVIEN__2725D70A7B1EC392");

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.MaCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NHANVIEN__MaCV__44FF419A");
            });

            modelBuilder.Entity<Thuebao>(entity =>
            {
                entity.HasKey(e => e.MaTb)
                    .HasName("PK__THUEBAO__2725006F7D3EA8F4");

                entity.Property(e => e.PhiHoaMang).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoThueBao).IsUnicode(false);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Thuebao)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__THUEBAO__MaDM__3E52440B");

                entity.HasOne(d => d.MaLtbNavigation)
                    .WithMany(p => p.Thuebao)
                    .HasForeignKey(d => d.MaLtb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__THUEBAO__MaLTB__3F466844");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.HasKey(e => e.MaTin)
                    .HasName("PK__TINTUC__3149033573F8C023");

                entity.Property(e => e.HinhAnh).IsUnicode(false);

                entity.Property(e => e.NgayDang).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
