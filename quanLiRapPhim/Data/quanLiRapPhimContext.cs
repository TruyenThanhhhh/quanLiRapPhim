using Microsoft.EntityFrameworkCore;
using quanLiRapPhim.Models;
using System.Collections.Generic;
using System.Linq;

namespace quanLiRapPhim.Data
{
    public class quanLiRapPhimContext : DbContext
    {
        public quanLiRapPhimContext(DbContextOptions<quanLiRapPhimContext> options)
            : base(options)
        {
        }

        public DbSet<DonHang> DonHang { get; set; } = default!;
        public DbSet<NhanVien> NhanVien { get; set; } = default!;
        public DbSet<Phim> Phim { get; set; } = default!;
        public DbSet<PhongChieu> PhongChieu { get; set; } = default!;
        public DbSet<QuanLy> QuanLy { get; set; } = default!;
        public DbSet<TaiKhoan> TaiKhoan { get; set; } = default!;
        public DbSet<ThongKe> ThongKe { get; set; } = default!;
        public DbSet<XuatChieu> XuatChieu { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Disable cascade delete for ALL foreign key relationships in the database
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            // Now explicitly define the relationships for clarity (even though cascade delete is already disabled)

            // XuatChieu -> PhongChieu
            modelBuilder.Entity<XuatChieu>()
                .HasOne(x => x.PhongChieu)
                .WithMany(p => p.XuatChieus)
                .HasForeignKey(x => x.PhongID)
                .OnDelete(DeleteBehavior.NoAction);

            // DonHang -> XuatChieu
            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.XuatChieu)
                .WithMany(x => x.DonHangs)
                .HasForeignKey(d => d.XuatChieuId)
                .OnDelete(DeleteBehavior.NoAction);

            // DonHang -> PhongChieu
            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.PhongChieu)
                .WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.PhongChieuId)
                .OnDelete(DeleteBehavior.NoAction);

            // DonHang -> Phim
            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.Phim)
                .WithMany()
                .HasForeignKey(d => d.PhimId)
                .OnDelete(DeleteBehavior.NoAction);

            // DonHang -> ThongKe
            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.ThongKe)
                .WithMany()
                .HasForeignKey(d => d.IDThongKe)
                .OnDelete(DeleteBehavior.NoAction);

            // DonHang -> NhanVien
            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.NhanVien)
                .WithMany()
                .HasForeignKey(d => d.IDNhanVien)
                .OnDelete(DeleteBehavior.NoAction);

            // NhanVien -> TaiKhoan
            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.TaiKhoan)
                .WithMany()
                .HasForeignKey(nv => nv.Username)
                .OnDelete(DeleteBehavior.NoAction);

            // QuanLy -> TaiKhoan
            modelBuilder.Entity<QuanLy>()
                .HasOne(ql => ql.TaiKhoan)
                .WithMany()
                .HasForeignKey(ql => ql.Username)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}