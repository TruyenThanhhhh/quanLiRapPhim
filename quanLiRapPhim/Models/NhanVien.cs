using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quanLiRapPhim.Models
{
    public class NhanVien
    {
        [Key]
        public int IDNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [ForeignKey("Username")]
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
