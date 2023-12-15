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
        public virtual DbSet<NhanKeHoachResponse> NhanKeHoachResponses { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<NhomQuyenQuyen> NhomQuyenQuyens { get; set; }
        public virtual DbSet<NhomQuyen> NhomQuyens { get; set; }
        public virtual DbSet<NhomNguoiDung> NhomNguoiDungs { get; set; }
        public virtual DbSet<QuyenResponse> QuyenResponses { get; set; }
        public virtual DbSet<NhomQuyenQuyenResponse> NhomQuyenQuyenResponses { get; set; }
        public virtual DbSet<NhomQuyenResponse> NhomQuyenResponses { get; set; }
        public virtual DbSet<NhomNDResponse> NhomNDResponses { get; set; }
        public virtual DbSet<BH_HV> BH_HVs { get; set; }
        public virtual DbSet<BuoiHoc> BuoiHocs { get; set; }
        public virtual DbSet<HV_TTB> HV_TTBs { get; set; }
        public virtual DbSet<KetQuaHL> KetQuaHLs { get; set; }
        public virtual DbSet<TotalDonViResponse> TotalDonViResponses { get; set; }
        public virtual DbSet<TotalHocVienResponse> TotalHocVienResponses { get; set; }
        public virtual DbSet<KetQuaHLResponse> KetQuaHLResponses { get; set; }
        public virtual DbSet<TotalKQResponse> TotalKQResponses { get; set; }
        public virtual DbSet<BH_HVResponse> BH_HVResponses { get; set; }
        public virtual DbSet<TotalNguoiDungResponse> TotalNguoiDungResponses { get; set; }
        public virtual DbSet<TotalTTBResponse> TotalTTBResponses { get; set; }
        public virtual DbSet<ThongKeByDonViResponse> ThongKeByDonViResponses { get; set; }
        public virtual DbSet<ThongKeByHocVienResponse> ThongKeByHocVienResponses { get; set; }
    }
}
