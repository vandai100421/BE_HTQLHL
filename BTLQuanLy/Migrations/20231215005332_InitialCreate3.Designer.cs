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
    [Migration("20231215005332_InitialCreate3")]
    partial class InitialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTLQuanLy.Models.BH_HV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuoiHocId")
                        .HasColumnType("int");

                    b.Property<int?>("CoMat")
                        .HasColumnType("int");

                    b.Property<int?>("DonViId")
                        .HasColumnType("int");

                    b.Property<int?>("HocVienId")
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

                    b.ToTable("BH_HVs");
                });

            modelBuilder.Entity("BTLQuanLy.Models.BuoiHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KeHoachId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGian")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ThuTu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BuoiHocs");
                });

            modelBuilder.Entity("BTLQuanLy.Models.HV_TTB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HocVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgaySua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<int?>("TTBId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HV_TTBs");
                });

            modelBuilder.Entity("BTLQuanLy.Models.KetQuaHL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HocVienId")
                        .HasColumnType("int");

                    b.Property<int?>("KeHoachID")
                        .HasColumnType("int");

                    b.Property<int?>("KetQua")
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

                    b.ToTable("KetQuaHLs");
                });
#pragma warning restore 612, 618
        }
    }
}