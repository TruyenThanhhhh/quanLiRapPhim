using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quanLiRapPhim.Models;

namespace quanLiRapPhim.Data
{
    public class quanLiRapPhimContext : DbContext
    {
        public quanLiRapPhimContext (DbContextOptions<quanLiRapPhimContext> options)
            : base(options)
        {
        }

        public DbSet<quanLiRapPhim.Models.DonHang> DonHang { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.NhanVien> NhanVien { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.Phim> Phim { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.PhongChieu> PhongChieu { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.QuanLy> QuanLy { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.TaiKhoan> TaiKhoan { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.ThongKe> ThongKe { get; set; } = default!;
        public DbSet<quanLiRapPhim.Models.XuatChieu> XuatChieu { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ràng buộc khóa ngoại với XuatChieuId trong bảng DonHang
            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.XuatChieu)
                .WithMany()  // Tùy vào mối quan hệ bạn muốn giữa DonHang và XuatChieu
                .HasForeignKey(d => d.XuatChieuId)
                .OnDelete(DeleteBehavior.NoAction);  // Tránh hành động cascade delete

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.PhongChieu)
                .WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.PhongChieuId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.Phim)
                .WithMany()
                .HasForeignKey(d => d.PhimId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.ThongKe)
                .WithMany()
                .HasForeignKey(d => d.IDThongKe)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.NhanVien)
                .WithMany()
                .HasForeignKey(d => d.IDNhanVien)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
