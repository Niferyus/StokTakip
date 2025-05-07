using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class HareketlerDal : GenericRepository<Hareketler>, IHareketlerDal
    {
        public HareketlerDal(Context context) : base(context)
        {

        }

        public async Task<Pagination<HareketlerDto>> GetAllDto(int pageIndex, int pageSize)
        {
            var query = from hareket in _context.Hareketler
                        join kisi in _context.Kisiler on hareket.KisiId equals kisi.Id
                        join urun in _context.Urunler on hareket.UrunId equals urun.Id
                        join depo in _context.Depo on hareket.DepoId equals depo.Id
                        select new HareketlerDto
                        {
                            Id = hareket.Id,
                            KisiAdi = kisi.Ad,
                            DepoAdi = depo.Ad,
                            UrunAdi = urun.Adi,
                            Miktar = hareket.Miktar,
                            BirimFiyat = hareket.BirimFiyat,
                            ToplamFiyat = hareket.ToplamFiyat,
                            Tarih = hareket.Tarih,
                            IslemTuru = hareket.IslemTuru,
                        };
            return await Task.Run(() => Pagination<HareketlerDto>.Create(query.AsQueryable(), pageIndex, pageSize));
        }
    }
}
