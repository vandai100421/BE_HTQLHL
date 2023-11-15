﻿using System;
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

        public virtual DbSet<DonViResponse> DonViResponses { get; set; }

        public virtual DbSet<HocVienResponse> HocVienResponses { get; set; }
    }
}
