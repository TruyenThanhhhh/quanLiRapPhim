using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quanLiRapPhim.Models
{
    public class ThongKe
    {
        [Key]
        public int IDThongKe { get; set; }

        [Required]
        public DateTime NgayTK { get; set; }

        [Required]
        public int ThangTK { get; set; }

        [Required]
        public int QuyTK { get; set; }

        [Required]
        public decimal DoanhThu { get; set; }
    }

}
