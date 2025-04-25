using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanLiRapPhim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_NhanVien_IDNhanVien",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_Phim_PhimId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_PhongChieu_PhongChieuId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_ThongKe_IDThongKe",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_NhanVien_IDNhanVien",
                table: "DonHang",
                column: "IDNhanVien",
                principalTable: "NhanVien",
                principalColumn: "IDNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_Phim_PhimId",
                table: "DonHang",
                column: "PhimId",
                principalTable: "Phim",
                principalColumn: "PhimID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_PhongChieu_PhongChieuId",
                table: "DonHang",
                column: "PhongChieuId",
                principalTable: "PhongChieu",
                principalColumn: "PhongID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_ThongKe_IDThongKe",
                table: "DonHang",
                column: "IDThongKe",
                principalTable: "ThongKe",
                principalColumn: "IDThongKe",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang",
                column: "XuatChieuId",
                principalTable: "XuatChieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_NhanVien_IDNhanVien",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_Phim_PhimId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_PhongChieu_PhongChieuId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_ThongKe_IDThongKe",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_NhanVien_IDNhanVien",
                table: "DonHang",
                column: "IDNhanVien",
                principalTable: "NhanVien",
                principalColumn: "IDNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_Phim_PhimId",
                table: "DonHang",
                column: "PhimId",
                principalTable: "Phim",
                principalColumn: "PhimID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_PhongChieu_PhongChieuId",
                table: "DonHang",
                column: "PhongChieuId",
                principalTable: "PhongChieu",
                principalColumn: "PhongID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_ThongKe_IDThongKe",
                table: "DonHang",
                column: "IDThongKe",
                principalTable: "ThongKe",
                principalColumn: "IDThongKe");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang",
                column: "XuatChieuId",
                principalTable: "XuatChieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
