using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class IslemlerRepository : IIslemlerRepository
    {
        private readonly Context context;

        public IslemlerRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Islemler islem)
        {
            context.Islemler.Add(islem);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var islem = GetById(id);
            if (islem != null)
            {
                context.Islemler.Remove(islem);
                context.SaveChanges();
            }
        }

        public List<Islemler> GetAll()
        {
            return context.Islemler.ToList();
        }

        public Islemler GetById(int id)
        {
            return context.Islemler.FirstOrDefault(x => x.IslemlerID == id);
        }

        public List<IslemlerDto> GetAllDtos()
        {
            var query = from islem in context.Islemler
                        join urun in context.Urunler on islem.UrunID equals urun.UrunID into urunGroup
                        from urun in urunGroup.DefaultIfEmpty()
                        join musteri in context.Musteriler on islem.MusteriID equals musteri.MusteriID into musteriGroup
                        from musteri in musteriGroup.DefaultIfEmpty()
                        join toptanci in context.Toptancilar on islem.ToptanciID equals toptanci.ToptanciID into toptanciGroup
                        from toptanci in toptanciGroup.DefaultIfEmpty()
                        select new IslemlerDto
                        {
                            IslemlerId = islem.IslemlerID,
                            UrunAdi = urun != null ? urun.UrunAdi : null,
                            MusteriAdi = musteri != null ? musteri.MusteriAdi : null,
                            ToptanciAdi = toptanci != null ? toptanci.ToptanciAdi : null,
                            Adet = islem.Adet,
                            ToplamFiyat = islem.ToplamFiyat,
                            Tarih = islem.Tarih,
                            SatisTipi = islem.Satis
                        };
            return query.ToList();
        }

        public void Update(Islemler islem)
        {
            context.Islemler.Update(islem);
            context.SaveChanges();          
        }
    }
}
