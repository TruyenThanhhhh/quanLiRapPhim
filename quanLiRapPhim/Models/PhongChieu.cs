using System.ComponentModel.DataAnnotations;

namespace quanLiRapPhim.Models
{
    public class PhongChieu
    {
        [Key]
        public int PhongID { get; set; }

        [Required]
        public int SoGhe { get; set; }

        // Navigation
        public virtual ICollection<XuatChieu> XuatChieus { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }

}
