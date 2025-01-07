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
        DbSet<Islemler> Islemler { get; set; }
        DbSet<Musteriler> Musteriler { get; set; }
        DbSet<Toptancilar> Toptancilar { get; set; }
        DbSet<Urunler> Urunler { get; set; }
        public Context(DbContextOptions<Context> options)
        : base(options) { }

    }
}
