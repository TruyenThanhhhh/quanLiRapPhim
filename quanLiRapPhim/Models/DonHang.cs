using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanLiRapPhim.Models
{
    public class DonHang
    {
        [Key]
        public int MaVe { get; set; }

        [Required]
        public int PhongChieuId { get; set; }

        [Required]
        public int XuatChieuId { get; set; }

        [Required]
        public int MaGhe { get; set; }

        [Required]
        public float GiaVe { get; set; }

        [Required]
        public DateTime NgayDat { get; set; }

        [Required]
        public int PhimId { get; set; }

        public int? IDThongKe { get; set; }

        [Required]
        public int IDNhanVien { get; set; }

        // Navigation properties
        [ForeignKey("PhongChieuId")]
        public virtual PhongChieu PhongChieu { get; set; }

        [ForeignKey("XuatChieuId")]
        public virtual XuatChieu XuatChieu { get; set; }

        [ForeignKey("PhimId")]
        public virtual Phim Phim { get; set; }

        [ForeignKey("IDThongKe")]
        public virtual ThongKe ThongKe { get; set; }

        [ForeignKey("IDNhanVien")]
        public virtual NhanVien NhanVien { get; set; }
    }
}