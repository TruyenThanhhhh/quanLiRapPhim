using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanLiRapPhim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate２ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang");

            migrationBuilder.AddColumn<int>(
                name: "XuatChieuID",
                table: "DonHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_XuatChieuID",
                table: "DonHang",
                column: "XuatChieuID");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuID",
                table: "DonHang",
                column: "XuatChieuID",
                principalTable: "XuatChieu",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang",
                column: "XuatChieuId",
                principalTable: "XuatChieu",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuID",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_XuatChieuID",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "XuatChieuID",
                table: "DonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_XuatChieu_XuatChieuId",
                table: "DonHang",
                column: "XuatChieuId",
                principalTable: "XuatChieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
