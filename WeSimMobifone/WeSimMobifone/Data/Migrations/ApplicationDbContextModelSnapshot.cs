﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeSimMobifone.Data;

namespace WeSimMobifone.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeSimMobifone.Models.Chucvu", b =>
                {
                    b.Property<int>("MaCv")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaCV")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("HeSo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValueSql("((1.0))");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaCv")
                        .HasName("PK__CHUCVU__27258E760A90F187");

                    b.ToTable("CHUCVU");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Cuahang", b =>
                {
                    b.Property<int>("MaCh")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaCH")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("DienThoai")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaCh")
                        .HasName("PK__CUAHANG__27258E00A6FC429C");

                    b.ToTable("CUAHANG");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Danhmuc", b =>
                {
                    b.Property<int>("MaDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaDM")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenDm")
                        .IsRequired()
                        .HasColumnName("TenDM")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaDm")
                        .HasName("PK__DANHMUC__2725866E4D38EA83");

                    b.ToTable("DANHMUC");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Diachi", b =>
                {
                    b.Property<int>("MaDc")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaDC")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Daxoa")
                        .HasColumnType("int");

                    b.Property<string>("DiaChi1")
                        .IsRequired()
                        .HasColumnName("DiaChi")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("MaKh")
                        .HasColumnName("MaKH")
                        .HasColumnType("int");

                    b.Property<int>("MacDinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("PhuongXa")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("QuanHuyen")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TinhThanh")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("MaDc")
                        .HasName("PK__DIACHI__2725866413E61BCE");

                    b.HasIndex("MaKh");

                    b.ToTable("DIACHI");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Hoadon", b =>
                {
                    b.Property<int>("MaHd")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaHD")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Daxoa")
                        .HasColumnType("int");

                    b.Property<int>("MaDc")
                        .HasColumnName("MaDc")
                        .HasColumnType("int");

                    b.Property<int>("MaKh")
                        .HasColumnName("MaKH")
                        .HasColumnType("int");

                    b.Property<int>("MaTb")
                        .HasColumnName("MaTB")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Ngay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("TongTien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("MaHd")
                        .HasName("PK__HOADON__2725A6E04A44D4E6");

                    b.HasIndex("MaDc");

                    b.HasIndex("MaKh");

                    b.HasIndex("MaTb");

                    b.ToTable("HOADON");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Huongdan", b =>
                {
                    b.Property<int>("MaHdan")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaHDan")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CauHoi")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("NgayDang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("TraLoi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHdan")
                        .HasName("PK__HUONGDAN__1418FD7DA043E111");

                    b.ToTable("HUONGDAN");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Khachhang", b =>
                {
                    b.Property<int>("MaKh")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaKH")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cccd")
                        .HasColumnName("CCCD")
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12)
                        .IsUnicode(false);

                    b.Property<int>("Daxoa")
                        .HasColumnType("int");

                    b.Property<string>("DienThoai")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("HinhS")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("HinhT")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("MatKhau")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("SlthueB")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SLThueB")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaKh")
                        .HasName("PK__KHACHHAN__2725CF1E7F7646D8");

                    b.ToTable("KHACHHANG");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Loaitb", b =>
                {
                    b.Property<int>("MaLtb")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaLTB")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenL")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaLtb")
                        .HasName("PK__LOAITB__3B98372DA0158673");

                    b.ToTable("LOAITB");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Nhanvien", b =>
                {
                    b.Property<int>("MaNv")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaNV")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Daxoa")
                        .HasColumnType("int");

                    b.Property<string>("DienThoai")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("MaCv")
                        .HasColumnName("MaCV")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MaNv")
                        .HasName("PK__NHANVIEN__2725D70A7B1EC392");

                    b.HasIndex("MaCv");

                    b.ToTable("NHANVIEN");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Qlthuebao", b =>
                {
                    b.Property<int>("MaQl")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaQL")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Daxoa")
                        .HasColumnType("int");

                    b.Property<int>("MaKh")
                        .HasColumnName("MaKH")
                        .HasColumnType("int");

                    b.Property<int>("MaTb")
                        .HasColumnName("MaTB")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayKichHoat")
                        .HasColumnType("datetime");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaQl");

                    b.HasIndex("MaKh");

                    b.HasIndex("MaTb");

                    b.ToTable("QLTHUEBAO");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Thuebao", b =>
                {
                    b.Property<int>("MaTb")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaTB")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Daxoa")
                        .HasColumnType("int");

                    b.Property<string>("DiaDiemHm")
                        .HasColumnName("DiaDiemHM")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LoaiSo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MaDm")
                        .HasColumnName("MaDM")
                        .HasColumnType("int");

                    b.Property<int>("MaLtb")
                        .HasColumnName("MaLTB")
                        .HasColumnType("int");

                    b.Property<int>("PhiHoaMang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("SoThueBao")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaTb")
                        .HasName("PK__THUEBAO__2725006F7D3EA8F4");

                    b.HasIndex("MaDm");

                    b.HasIndex("MaLtb");

                    b.ToTable("THUEBAO");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Tintuc", b =>
                {
                    b.Property<int>("MaTin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HinhAnh")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<DateTime?>("NgayDang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TomTat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTin")
                        .HasName("PK__TINTUC__3149033573F8C023");

                    b.ToTable("TINTUC");
                });

            modelBuilder.Entity("WeSimMobifone.Models.Diachi", b =>
                {
                    b.HasOne("WeSimMobifone.Models.Khachhang", "MaKhNavigation")
                        .WithMany("Diachi")
                        .HasForeignKey("MaKh")
                        .HasConstraintName("FK__DIACHI__MaKH__4AB81AF0")
                        .IsRequired();
                });

            modelBuilder.Entity("WeSimMobifone.Models.Hoadon", b =>
                {
                    b.HasOne("WeSimMobifone.Models.Diachi", "MaDcNavigation")
                        .WithMany("Hoadon")
                        .HasForeignKey("MaDc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeSimMobifone.Models.Khachhang", "MaKhNavigation")
                        .WithMany("Hoadon")
                        .HasForeignKey("MaKh")
                        .HasConstraintName("FK__HOADON__MaKH__5165187F")
                        .IsRequired();

                    b.HasOne("WeSimMobifone.Models.Thuebao", "MaTbNavigation")
                        .WithMany("Hoadon")
                        .HasForeignKey("MaTb")
                        .HasConstraintName("FK__HOADON__MaTB__4E88ABD4")
                        .IsRequired();
                });

            modelBuilder.Entity("WeSimMobifone.Models.Nhanvien", b =>
                {
                    b.HasOne("WeSimMobifone.Models.Chucvu", "MaCvNavigation")
                        .WithMany("Nhanvien")
                        .HasForeignKey("MaCv")
                        .HasConstraintName("FK__NHANVIEN__MaCV__44FF419A")
                        .IsRequired();
                });

            modelBuilder.Entity("WeSimMobifone.Models.Qlthuebao", b =>
                {
                    b.HasOne("WeSimMobifone.Models.Khachhang", "MaKhNavigation")
                        .WithMany("Qlthuebao")
                        .HasForeignKey("MaKh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeSimMobifone.Models.Thuebao", "MaTbNavigation")
                        .WithMany("Qlthuebao")
                        .HasForeignKey("MaTb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeSimMobifone.Models.Thuebao", b =>
                {
                    b.HasOne("WeSimMobifone.Models.Danhmuc", "MaDmNavigation")
                        .WithMany("Thuebao")
                        .HasForeignKey("MaDm")
                        .HasConstraintName("FK__THUEBAO__MaDM__3E52440B")
                        .IsRequired();

                    b.HasOne("WeSimMobifone.Models.Loaitb", "MaLtbNavigation")
                        .WithMany("Thuebao")
                        .HasForeignKey("MaLtb")
                        .HasConstraintName("FK__THUEBAO__MaLTB__3F466844")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
