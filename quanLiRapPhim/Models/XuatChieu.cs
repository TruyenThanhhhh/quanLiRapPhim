using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanLiRapPhim.Models
{
    public class XuatChieu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int PhongID { get; set; }

        [Required]
        public DateTime GioChieu { get; set; }

        public float? KhuyenMai { get; set; }

        // Navigation
        [ForeignKey("PhongID")]
        public virtual PhongChieu PhongChieu { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }

}
