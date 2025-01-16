using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Islemler> Islemler { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Toptancilar> Toptancilar { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Furkan;initial catalog=StokTakipDB;integrated security=true;TrustServerCertificate=true");
        }
    }
}
