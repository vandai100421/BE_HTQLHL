using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTLQuanLy.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapBacs");

            migrationBuilder.DropTable(
                name: "CapDonVis");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "DonVis");


            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "KHHuanLuyens");

            migrationBuilder.DropTable(
                name: "LoaiDonVis");


            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "NhanKeHoachs");

            migrationBuilder.DropTable(
                name: "TranThietBis");

            migrationBuilder.CreateTable(
                name: "NhomNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhomND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhomQuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomNguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyenQuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhomQuyenId = table.Column<int>(type: "int", nullable: false),
                    QuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyenQuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhomQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhomNguoiDungs");

            migrationBuilder.DropTable(
                name: "NhomQuyenQuyens");

            migrationBuilder.DropTable(
                name: "NhomQuyens");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.CreateTable(
                name: "CapBacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenCapBac = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapBacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapDonVis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenCapDv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapDonVis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiChucVu = table.Column<int>(type: "int", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "DonVis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapDonViId = table.Column<int>(type: "int", nullable: true),
                    DonViId = table.Column<int>(type: "int", nullable: true),
                    LoaiDonViId = table.Column<int>(type: "int", nullable: true),
                    NgayGiaiTan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonVis_DonVis_DonViId",
                        column: x => x.DonViId,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapBacId = table.Column<int>(type: "int", nullable: true),
                    ChucVuId = table.Column<int>(type: "int", nullable: true),
                    DonViId = table.Column<int>(type: "int", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    MaHocVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHocVien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KHHuanLuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiGui = table.Column<int>(type: "int", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenKeHoach = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHHuanLuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDonVis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenLoaiDv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDonVis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaiTro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanKeHoachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    KeHoachId = table.Column<int>(type: "int", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanKeHoachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranThietBis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapDo = table.Column<int>(type: "int", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    TenTTB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranThietBis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_DonViId",
                table: "DonVis",
                column: "DonViId");
        }
    }
}
