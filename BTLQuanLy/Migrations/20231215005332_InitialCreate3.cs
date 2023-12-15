using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTLQuanLy.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "BH_HVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuoiHocId = table.Column<int>(type: "int", nullable: true),
                    HocVienId = table.Column<int>(type: "int", nullable: true),
                    CoMat = table.Column<int>(type: "int", nullable: true),
                    DonViId = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BH_HVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuoiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeHoachId = table.Column<int>(type: "int", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuoiHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HV_TTBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocVienId = table.Column<int>(type: "int", nullable: true),
                    TTBId = table.Column<int>(type: "int", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HV_TTBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaHLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeHoachID = table.Column<int>(type: "int", nullable: true),
                    HocVienId = table.Column<int>(type: "int", nullable: true),
                    KetQua = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<int>(type: "int", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaHLs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BH_HVs");

            migrationBuilder.DropTable(
                name: "BuoiHocs");

            migrationBuilder.DropTable(
                name: "HV_TTBs");

            migrationBuilder.DropTable(
                name: "KetQuaHLs");

            migrationBuilder.CreateTable(
                name: "NhomNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhomQuyenId = table.Column<int>(type: "int", nullable: false),
                    TenNhomND = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
