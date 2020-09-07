using System;
using System.Collections.Generic;
using System.Text;
using DaryaVaria.Web.Data.Business;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DaryaVaria.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LaporanProduk> LaporanProduk { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}
