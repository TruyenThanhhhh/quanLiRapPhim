using System.ComponentModel.DataAnnotations;

namespace quanLiRapPhim.Models
{
    public class Phim
    {
        [Key]
        public int PhimID { get; set; }

        [Required]
        [StringLength(255)]
        public string TenPhim { get; set; }

        [Required]
        [StringLength(10)]
        public string GioiHanDoTuoi { get; set; } // 'P', 'K', 'T13', 'T16', 'T18'

        [Required]
        [StringLength(255)]
        public string DaoDien { get; set; }

        [Required]
        [StringLength(100)]
        public string TheLoai { get; set; } // 'Hoạt hình', 'Kinh dị', ...

        [Required]
        [StringLength(50)]
        public string QuocGia { get; set; }
    }
}
