using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Islemler> Islemler { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Toptancilar> Toptancilar { get; set; }
        public DbSet<Urunler> Urunler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Furkan;initial catalog=StokTakipDB;integrated security=true;TrustServerCertificate=true");
        }
    }
}
