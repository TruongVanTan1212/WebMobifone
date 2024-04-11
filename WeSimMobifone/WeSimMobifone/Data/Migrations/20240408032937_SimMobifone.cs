using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeSimMobifone.Data.Migrations
{
    public partial class SimMobifone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CHUCVU",
                columns: table => new
                {
                    MaCV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 100, nullable: false),
                    HeSo = table.Column<double>(nullable: true, defaultValueSql: "((1.0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHUCVU__27258E760A90F187", x => x.MaCV);
                });

            migrationBuilder.CreateTable(
                name: "CUAHANG",
                columns: table => new
                {
                    MaCH = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CUAHANG__27258E00A6FC429C", x => x.MaCH);
                });

            migrationBuilder.CreateTable(
                name: "DANHMUC",
                columns: table => new
                {
                    MaDM = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDM = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DANHMUC__2725866E4D38EA83", x => x.MaDM);
                });

            migrationBuilder.CreateTable(
                name: "HUONGDAN",
                columns: table => new
                {
                    MaHDan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoi = table.Column<string>(maxLength: 255, nullable: true),
                    TraLoi = table.Column<string>(nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HUONGDAN__1418FD7DA043E111", x => x.MaHDan);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MaKH = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    CCCD = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    HinhT = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    HinhS = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    SLThueB = table.Column<int>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACHHAN__2725CF1E7F7646D8", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "LOAITB",
                columns: table => new
                {
                    MaLTB = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenL = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAITB__3B98372DA0158673", x => x.MaLTB);
                });

            migrationBuilder.CreateTable(
                name: "TINTUC",
                columns: table => new
                {
                    MaTin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(nullable: true),
                    TomTat = table.Column<string>(nullable: true),
                    NoiDung = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TINTUC__3149033573F8C023", x => x.MaTin);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MaNV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 100, nullable: false),
                    MaCV = table.Column<int>(nullable: false),
                    DienThoai = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHANVIEN__2725D70A7B1EC392", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK__NHANVIEN__MaCV__44FF419A",
                        column: x => x.MaCV,
                        principalTable: "CHUCVU",
                        principalColumn: "MaCV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIACHI",
                columns: table => new
                {
                    MaDC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(nullable: false),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: false),
                    PhuongXa = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    QuanHuyen = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TinhThanh = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MacDinh = table.Column<int>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DIACHI__2725866413E61BCE", x => x.MaDC);
                    table.ForeignKey(
                        name: "FK__DIACHI__MaKH__4AB81AF0",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THUEBAO",
                columns: table => new
                {
                    MaTB = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoThueBao = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PhiHoaMang = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    MaDM = table.Column<int>(nullable: false),
                    MaLTB = table.Column<int>(nullable: false),
                    LoaiSo = table.Column<string>(maxLength: 50, nullable: true),
                    DiaDiemHM = table.Column<string>(maxLength: 100, nullable: true),
                    TrangThai = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__THUEBAO__2725006F7D3EA8F4", x => x.MaTB);
                    table.ForeignKey(
                        name: "FK__THUEBAO__MaDM__3E52440B",
                        column: x => x.MaDM,
                        principalTable: "DANHMUC",
                        principalColumn: "MaDM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__THUEBAO__MaLTB__3F466844",
                        column: x => x.MaLTB,
                        principalTable: "LOAITB",
                        principalColumn: "MaLTB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTB = table.Column<int>(nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    TongTien = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    MaKH = table.Column<int>(nullable: false),
                    MaDc = table.Column<int>(nullable: false),
                    TrangThai = table.Column<int>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOADON__2725A6E04A44D4E6", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HOADON_DIACHI_MaDc",
                        column: x => x.MaDc,
                        principalTable: "DIACHI",
                        principalColumn: "MaDC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__HOADON__MaKH__5165187F",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__HOADON__MaTB__4E88ABD4",
                        column: x => x.MaTB,
                        principalTable: "THUEBAO",
                        principalColumn: "MaTB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DIACHI_MaKH",
                table: "DIACHI",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaDc",
                table: "HOADON",
                column: "MaDc");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaKH",
                table: "HOADON",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaTB",
                table: "HOADON",
                column: "MaTB");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_MaCV",
                table: "NHANVIEN",
                column: "MaCV");

            migrationBuilder.CreateIndex(
                name: "IX_THUEBAO_MaDM",
                table: "THUEBAO",
                column: "MaDM");

            migrationBuilder.CreateIndex(
                name: "IX_THUEBAO_MaLTB",
                table: "THUEBAO",
                column: "MaLTB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUAHANG");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "HUONGDAN");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "TINTUC");

            migrationBuilder.DropTable(
                name: "DIACHI");

            migrationBuilder.DropTable(
                name: "THUEBAO");

            migrationBuilder.DropTable(
                name: "CHUCVU");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "DANHMUC");

            migrationBuilder.DropTable(
                name: "LOAITB");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
