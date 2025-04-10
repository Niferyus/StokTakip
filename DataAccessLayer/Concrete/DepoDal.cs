using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DepoDal : GenericRepository<Depo>, IDepoDal
    {
        public DepoDal(Context context) : base(context)
        {
            
        }

        public async Task<Pagination<DepoDto>> GetAllDepo(int pageIndex, int pageSize)
        {
            var query = from depo in _context.Depo
                        join il in _context.Yerlesim on depo.SehirId equals il.Id
                        join ilce in _context.Yerlesim on depo.IlceId equals ilce.Id
                        where depo.Active == true
                        select new DepoDto
                        {
                            Id = depo.Id,
                            Ad = depo.Ad,
                            Sehir = il.Ad,
                            Ilce = ilce.Ad,
                            Adres = depo.Adres,
                            Mail = depo.Mail,
                            Yetkili = depo.Yetkili,
                            Aciklama = depo.Aciklama
                        };
            return await Task.Run(() => Pagination<DepoDto>.Create(query, pageIndex, pageSize));
        }

        //public async Task<Pagination<Urunler>> GetDepoUrunler(int depoId)
        //{
        //    var values = from stok in _context.Stok
        //                 join urun in _context.Urunler on stok.UrunId equals urun.Id
        //                 where stok.DepoId == depoId
        //                 select new DepoUrunDto
        //                 {
        //                     stok.StokMiktari
        //                 }
        //}

        public async Task Edit(Depo entity)
        {
            var existingEntity = await GetById(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Yerlesim>> GetAllYerlesim(int id)
        {
            var items =  await (id == 0
                            ? _context.Yerlesim.Where(x => x.UstYerlesimId == 0)
                            : _context.Yerlesim.Where(x => x.UstYerlesimId == id))
                            .ToListAsync();
            return items;
        }

        public async Task<int> GetSehirIdByName(string sehirAdi)
        {
            return await _context.Yerlesim.Where(x => x.Ad == sehirAdi && x.UstYerlesimId == 0)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetIlceIdByName(string ilceAdi)
        {
            return await _context.Yerlesim.Where(x => x.Ad == ilceAdi && x.UstYerlesimId != 0)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetIlceNameById(int ilceId)
        {
            var ilceAdi = await _context.Yerlesim
                .Where(x => x.Id == ilceId)
                .Select(x => x.Ad)
                .FirstOrDefaultAsync();

            if (ilceAdi == null)
                throw new InvalidOperationException($"İlçe bulunamadı. (ID: {ilceId})");

            return ilceAdi;
        }

        public async Task<string> GetSehirNameById(int sehirId)
        {
            var sehirAdi = await _context.Yerlesim
                .Where(x => x.Id == sehirId)
                .Select(x => x.Ad)
                .FirstOrDefaultAsync();

            if (sehirAdi == null)
                throw new InvalidOperationException($"İlçe bulunamadı. (ID: {sehirId})");

            return sehirAdi;
        }
    }
}
