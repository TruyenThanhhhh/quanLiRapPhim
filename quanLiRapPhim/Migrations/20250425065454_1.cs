using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanLiRapPhim.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phim",
                columns: table => new
                {
                    PhimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhim = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GioiHanDoTuoi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DaoDien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim", x => x.PhimID);
                });

            migrationBuilder.CreateTable(
                name: "PhongChieu",
                columns: table => new
                {
                    PhongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoGhe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongChieu", x => x.PhongID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SoChungMinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "ThongKe",
                columns: table => new
                {
                    IDThongKe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThangTK = table.Column<int>(type: "int", nullable: false),
                    QuyTK = table.Column<int>(type: "int", nullable: false),
                    DoanhThu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongKe", x => x.IDThongKe);
                });

            migrationBuilder.CreateTable(
                name: "XuatChieu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongID = table.Column<int>(type: "int", nullable: false),
                    GioChieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhuyenMai = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatChieu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_XuatChieu_PhongChieu_PhongID",
                        column: x => x.PhongID,
                        principalTable: "PhongChieu",
                        principalColumn: "PhongID");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IDNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_TaiKhoan_Username",
                        column: x => x.Username,
                        principalTable: "TaiKhoan",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "QuanLy",
                columns: table => new
                {
                    IDQuanLy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLy", x => x.IDQuanLy);
                    table.ForeignKey(
                        name: "FK_QuanLy_TaiKhoan_Username",
                        column: x => x.Username,
                        principalTable: "TaiKhoan",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongChieuId = table.Column<int>(type: "int", nullable: false),
                    XuatChieuId = table.Column<int>(type: "int", nullable: false),
                    MaGhe = table.Column<int>(type: "int", nullable: false),
                    GiaVe = table.Column<float>(type: "real", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhimId = table.Column<int>(type: "int", nullable: false),
                    IDThongKe = table.Column<int>(type: "int", nullable: true),
                    IDNhanVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaVe);
                    table.ForeignKey(
                        name: "FK_DonHang_NhanVien_IDNhanVien",
                        column: x => x.IDNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IDNhanVien");
                    table.ForeignKey(
                        name: "FK_DonHang_Phim_PhimId",
                        column: x => x.PhimId,
                        principalTable: "Phim",
                        principalColumn: "PhimID");
                    table.ForeignKey(
                        name: "FK_DonHang_PhongChieu_PhongChieuId",
                        column: x => x.PhongChieuId,
                        principalTable: "PhongChieu",
                        principalColumn: "PhongID");
                    table.ForeignKey(
                        name: "FK_DonHang_ThongKe_IDThongKe",
                        column: x => x.IDThongKe,
                        principalTable: "ThongKe",
                        principalColumn: "IDThongKe");
                    table.ForeignKey(
                        name: "FK_DonHang_XuatChieu_XuatChieuId",
                        column: x => x.XuatChieuId,
                        principalTable: "XuatChieu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_IDNhanVien",
                table: "DonHang",
                column: "IDNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_IDThongKe",
                table: "DonHang",
                column: "IDThongKe");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_PhimId",
                table: "DonHang",
                column: "PhimId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_PhongChieuId",
                table: "DonHang",
                column: "PhongChieuId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_XuatChieuId",
                table: "DonHang",
                column: "XuatChieuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_Username",
                table: "NhanVien",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLy_Username",
                table: "QuanLy",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_XuatChieu_PhongID",
                table: "XuatChieu",
                column: "PhongID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "QuanLy");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Phim");

            migrationBuilder.DropTable(
                name: "ThongKe");

            migrationBuilder.DropTable(
                name: "XuatChieu");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "PhongChieu");
        }
    }
}
