using System;
using BTLQuanLy.Models;
using BTLQuanLy.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTLQuanLy.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<LoaiDonVi> LoaiDonVis { get; set; }
        public virtual DbSet<CapDonVi> CapDonVis { get; set; }
        public virtual DbSet<CapBac> CapBacs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<TrangThietBi> TrangThietBis { get; set; }
        public virtual DbSet<KHHuanLuyen> KHHuanLuyens { get; set; }
        public virtual DbSet<NhanKeHoach> NhanKeHoachs { get; set; }
        public virtual DbSet<DonViResponse> DonViResponses { get; set; }
        public virtual DbSet<HocVienResponse> HocVienResponses { get; set; }
        public virtual DbSet<NguoiDungResponse> NguoiDungResponses { get; set; }
        public virtual DbSet<TrangThietBiResponse> TrangThietBiResponses { get; set; }
        public virtual DbSet<KHHuanLuyenResponse> KHHuanLuyenResponses { get; set; }
        public virtual DbSet<TotalKHResponse> TotalKHResponses { get; set; }
    }
}
