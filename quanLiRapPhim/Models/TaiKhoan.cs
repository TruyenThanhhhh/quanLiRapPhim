using System.ComponentModel.DataAnnotations;

namespace quanLiRapPhim.Models
{
    public class TaiKhoan
    {
        [Key]
        [StringLength(100)]
        public string Username { get; set; }  // Lấy Username làm Khóa Chính luôn

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(20)]
        public string SoChungMinh { get; set; }
    }
}
