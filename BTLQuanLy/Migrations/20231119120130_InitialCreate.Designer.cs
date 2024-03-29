﻿// <auto-generated />
using System;
using BTLQuanLy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTLQuanLy.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231119120130_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTLQuanLy.Models.CapBac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenCapBac")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CapBacs");
                });

            modelBuilder.Entity("BTLQuanLy.Models.CapDonVi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenCapDv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CapDonVis");
                });

            modelBuilder.Entity("BTLQuanLy.Models.ChucVu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LoaiChucVu")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChucVus");
                });

            modelBuilder.Entity("BTLQuanLy.Models.DonVi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CapDonViId")
                        .HasColumnType("int");

                    b.Property<int?>("DonViId")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiDonViId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayGiaiTan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonViId");

                    b.ToTable("DonVis");
                });

            modelBuilder.Entity("BTLQuanLy.Models.HocVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CapBacId")
                        .HasColumnType("int");

                    b.Property<int?>("ChucVuId")
                        .HasColumnType("int");

                    b.Property<int?>("DonViId")
                        .HasColumnType("int");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("MaHocVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("QueQuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHocVien")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HocViens");
                });

            modelBuilder.Entity("BTLQuanLy.Models.KHHuanLuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoiGui")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenKeHoach")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KHHuanLuyens");
                });

            modelBuilder.Entity("BTLQuanLy.Models.LoaiDonVi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiDv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiDonVis");
                });

            modelBuilder.Entity("BTLQuanLy.Models.NguoiDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonViId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("BTLQuanLy.Models.NhanKeHoach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonViId")
                        .HasColumnType("int");

                    b.Property<int>("KeHoachId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NhanKeHoachs");
                });

            modelBuilder.Entity("BTLQuanLy.Models.TrangThietBi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapDo")
                        .HasColumnType("int");

                    b.Property<string>("DiaDiem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DonViId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenTTB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TinhTrang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TranThietBis");
                });

            modelBuilder.Entity("BTLQuanLy.Response.DonViResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CapDonViId")
                        .HasColumnType("int");

                    b.Property<int?>("DonViId")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiDonViId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayGiaiTan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenCapDv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoaiDv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DonViResponses");
                });

            modelBuilder.Entity("BTLQuanLy.Response.HocVienResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CapBacId")
                        .HasColumnType("int");

                    b.Property<int?>("ChucVuId")
                        .HasColumnType("int");

                    b.Property<int?>("DonViId")
                        .HasColumnType("int");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("MaHocVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("QueQuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCapBac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHocVien")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HocVienResponses");
                });

            modelBuilder.Entity("BTLQuanLy.Response.NguoiDungResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonViId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NguoiDungResponses");
                });

            modelBuilder.Entity("BTLQuanLy.Models.DonVi", b =>
                {
                    b.HasOne("BTLQuanLy.Models.DonVi", null)
                        .WithMany("DonVis")
                        .HasForeignKey("DonViId");
                });

            modelBuilder.Entity("BTLQuanLy.Models.DonVi", b =>
                {
                    b.Navigation("DonVis");
                });
#pragma warning restore 612, 618
        }
    }
}
