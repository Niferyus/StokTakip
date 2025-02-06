using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Islemler> Islemler { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Toptancilar> Toptancilar { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Furkan;initial catalog=DBStokTakip;integrated security=true;TrustServerCertificate=true");
        }
    }
}
