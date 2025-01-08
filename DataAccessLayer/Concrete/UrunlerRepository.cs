using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UrunlerRepository : IUrunlerRepository
    {
        private readonly Context context;

        public UrunlerRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Urunler urun)
        {
            context.Urunler.Add(urun);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var urun = GetById(id);
            if (urun != null )
            {
                context.Urunler.Remove(urun);
                context.SaveChanges();
            }
        }

        public List<Urunler> GetAll()
        {
            return context.Urunler.ToList();
        }

        public Urunler GetById(int id)
        {
            return context.Urunler.FirstOrDefault(x => x.UrunID == id);
        }

        public void Update(Urunler urun)
        {
            context.Urunler.Update(urun);
            context.SaveChanges();
        }
    }
}
