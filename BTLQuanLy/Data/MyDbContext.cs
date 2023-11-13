using System;
using BTLQuanLy.Models;
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
        public virtual DbSet<DonViModel> DonViModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BTLQuanLy;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DonVi>(entity =>
            {
                entity.HasKey(e => e.IddonVi)
                    .HasName("PK__DonVi__082302BF13DA1DAB");
            });

            modelBuilder.Entity<HocVien>(entity =>
            {
                entity.HasKey(e => e.IdhocVien)
                    .HasName("PK__HocVien__0E2229D1923405CB");

                entity.Property(e => e.MaHocVien).IsFixedLength(true);

                entity.Property(e => e.SoDienThoai).IsFixedLength(true);
            });

            modelBuilder.Entity<LoaiDonVi>(entity =>
            {
                entity.HasKey(e => e.IdloaiDv)
                    .HasName("PK__LoaiDonV__B57CEB3E03801DBB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
