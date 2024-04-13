using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeSimMobifone.Data.Migrations
{
    public partial class dbCapNhat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "THUEBAO",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Daxoa",
                table: "THUEBAO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Daxoa",
                table: "NHANVIEN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SLThueB",
                table: "KHACHHANG",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Daxoa",
                table: "KHACHHANG",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HOADON",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Daxoa",
                table: "HOADON",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MacDinh",
                table: "DIACHI",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Daxoa",
                table: "DIACHI",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "HeSo",
                table: "CHUCVU",
                nullable: false,
                defaultValueSql: "((1.0))",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldDefaultValueSql: "((1.0))");

            migrationBuilder.CreateTable(
                name: "QLTHUEBAO",
                columns: table => new
                {
                    MaQL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTB = table.Column<int>(nullable: false),
                    MaKH = table.Column<int>(nullable: false),
                    NgayKichHoat = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Daxoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLTHUEBAO", x => x.MaQL);
                    table.ForeignKey(
                        name: "FK_QLTHUEBAO_KHACHHANG_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLTHUEBAO_THUEBAO_MaTB",
                        column: x => x.MaTB,
                        principalTable: "THUEBAO",
                        principalColumn: "MaTB",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QLTHUEBAO_MaKH",
                table: "QLTHUEBAO",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_QLTHUEBAO_MaTB",
                table: "QLTHUEBAO",
                column: "MaTB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QLTHUEBAO");

            migrationBuilder.DropColumn(
                name: "Daxoa",
                table: "THUEBAO");

            migrationBuilder.DropColumn(
                name: "Daxoa",
                table: "NHANVIEN");

            migrationBuilder.DropColumn(
                name: "Daxoa",
                table: "KHACHHANG");

            migrationBuilder.DropColumn(
                name: "Daxoa",
                table: "HOADON");

            migrationBuilder.DropColumn(
                name: "Daxoa",
                table: "DIACHI");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "THUEBAO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SLThueB",
                table: "KHACHHANG",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HOADON",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "MacDinh",
                table: "DIACHI",
                type: "int",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(int),
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<double>(
                name: "HeSo",
                table: "CHUCVU",
                type: "float",
                nullable: true,
                defaultValueSql: "((1.0))",
                oldClrType: typeof(double),
                oldDefaultValueSql: "((1.0))");
        }
    }
}
