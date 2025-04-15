using EntityLayer.Concrete.Class;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Islemler> Islemler { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Depo> Depo { get; set; }
        public DbSet<Yerlesim> Yerlesim { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<UrunOzellikleri> UrunOzellikleri { get; set; }
        public DbSet<Kisiler> Kisiler { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Base metodunu çağırın (Identity için)

            // Depo entity'sinde Sehir ile ilişkiyi tanımla
            modelBuilder.Entity<Depo>()
                .HasOne(d => d.Sehirr)
                .WithMany() // Depo'dan Sehir'e doğru tek yönlü ilişki
                .HasForeignKey(d => d.SehirId)
                .OnDelete(DeleteBehavior.Restrict); // Sehir silindiğinde Depo etkilenmez

            // Depo entity'sinde Ilce ile ilişkiyi tanımla
            modelBuilder.Entity<Depo>()
                .HasOne(d => d.Ilcee)
                .WithMany() // Depo'dan Ilce'ye doğru tek yönlü ilişki
                .HasForeignKey(d => d.IlceId)
                .OnDelete(DeleteBehavior.Restrict); // Ilce silindiğinde Depo etkilenmez
        }
    }
}
