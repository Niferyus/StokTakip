using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ToptancilarRepository : IToptancilarRepository
    {
        private readonly Context context;

        public ToptancilarRepository(Context context)
        {
            this.context = context;
        }
        public void Add(Toptancilar toptanci)
        {
            context.Toptancilar.Add(toptanci);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var toptanci = GetById(id);
            if (toptanci != null)
            {
                var islemler = context.Islemler.Where(i => i.ToptanciID == id).ToList();
                foreach (var islem in islemler)
                {
                    islem.ToptanciID = null;
                    context.Islemler.Update(islem);
                }
                context.SaveChanges();
                context.Toptancilar.Remove(toptanci);
                context.SaveChanges();
            }
        }

        public List<Toptancilar> GetAll()
        {
            return context.Toptancilar.ToList();
        }

        public List<ToptancilarDto> GetAllDto()
        {
            var query = from toptanci in context.Toptancilar
                        join urun in context.Urunler on toptanci.UrunId equals urun.Id into urunGroup
                        from urun in urunGroup.DefaultIfEmpty()
                        select new ToptancilarDto
                        {
                            ToptanciID = toptanci.ToptanciID,
                            ToptanciAdi = toptanci != null ? toptanci.ToptanciAdi : null,
                            UrunAdi = urun != null ? urun.Adi : null,
                            Adet = toptanci.Adet,
                            SatisFiyati = toptanci.SatisFiyati
                        };
            return query.ToList();
        }

        public Toptancilar GetById(int? id)
        {
            return context.Toptancilar.FirstOrDefault(x => x.ToptanciID == id);
        }

        public void Update(Toptancilar toptanci)
        {
            context.Toptancilar.Update(toptanci);
            context.SaveChanges();
        }
    }
}
