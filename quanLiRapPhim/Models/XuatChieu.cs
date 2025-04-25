using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanLiRapPhim.Models
{
    public class XuatChieu
    {
        public XuatChieu()
        {
            // Initialize collections to avoid null reference exceptions
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int PhongID { get; set; }

        [Required]
        public DateTime GioChieu { get; set; }

        public float? KhuyenMai { get; set; }

        // Navigation properties
        [ForeignKey("PhongID")]
        public virtual PhongChieu PhongChieu { get; set; }

        // Collection navigation property for DonHang
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}