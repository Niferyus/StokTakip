using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using EFCore.BulkExtensions;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UrunlerDal : GenericRepository<Urunler>, IUrunlerDal
    {
        public UrunlerDal(Context context) : base(context)
        {

        }
        public async Task<Pagination<UrunlerDto>> GetAllUrunlerDto(int pageIndex, int pageSize)
        {
            var query = from urun in _context.Urunler
                        join user in _context.Users on urun.InsUserId equals user.Id
                        where urun.Active == true
                        select new UrunlerDto
                        {
                            Id = urun.Id,
                            UserName = user.Name,
                            Marka = urun.Marka,
                            Adi = urun.Adi,
                            BarkodNo = urun.BarkodNo,
                            Aciklama = urun.Aciklama,
                            Birim = urun.Birim,
                            AlisFiyat = urun.AlisFiyat,
                            SatisFiyat = urun.SatisFiyat,
                            Stok = urun.Stok,
                            Tarih = urun.CreateDate,
                            KritikStokMiktarı = urun.KritikStokMiktarı,
                            EksikStokMiktarı = urun.EksikStokMiktarı
                        };
            return await Task.Run(() => Pagination<UrunlerDto>.Create(query.AsQueryable(), pageIndex, pageSize));
        }

        public async Task<Pagination<UrunlerDto>> GetByFilter(string marka, string adi, string barkod, string stok, string baslangicTarihi, string bitisTarihi, int pageIndex, int pageSize)
        {
            var query = from urun in _context.Urunler
                        join user in _context.Users on urun.InsUserId equals user.Id
                        where urun.Active == true
                        select new UrunlerDto
                        {
                            Id = urun.Id,
                            UserName = user.Name,
                            Marka = urun.Marka,
                            Adi = urun.Adi,
                            BarkodNo = urun.BarkodNo,
                            Aciklama = urun.Aciklama,
                            Birim = urun.Birim,
                            AlisFiyat = urun.AlisFiyat,
                            SatisFiyat = urun.SatisFiyat,
                            Stok = urun.Stok,
                            Tarih = urun.CreateDate
                        };

            if (!string.IsNullOrEmpty(marka))
                query = query.Where(x => x.Marka.Contains(marka));

            if (!string.IsNullOrEmpty(adi))
                query = query.Where(x => x.Adi.Contains(adi));

            if (!string.IsNullOrEmpty(barkod))
                query = query.Where(x => x.BarkodNo.Contains(barkod));

            if (!string.IsNullOrEmpty(stok))
            {
                if (stok == "StokVar")
                    query = query.Where(x => x.Stok > 0);
                else if (stok == "StokYok")
                    query = query.Where(x => x.Stok <= 0);
            }

            if (!string.IsNullOrEmpty(baslangicTarihi))
            {
                if (DateTime.TryParseExact(baslangicTarihi, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime baslangic))
                {
                    query = query.Where(x => x.Tarih.Date >= baslangic.Date);
                }
            }

            if (!string.IsNullOrEmpty(bitisTarihi))
            {
                if (DateTime.TryParseExact(bitisTarihi, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bitis))
                {
                    query = query.Where(x => x.Tarih.Date <= bitis.Date);
                }
            }

            var items = await Task.Run(() => Pagination<UrunlerDto>.Create(query.AsQueryable(), pageIndex, pageSize));
            return items;
        }

        public async Task BulkInsert(List<Urunler> items)
        {
            await _context.BulkInsertAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Urunler entity)
        {
            var existingEntity = await _context.Urunler.FindAsync(entity.Id);
            entity.InsUserId = existingEntity.InsUserId;
            entity.Active = existingEntity.Active;
            entity.Approved = existingEntity.Approved;
            entity.CreateDate = existingEntity.CreateDate;
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Pagination<Urunler>> GetDepoUrunler(int depoId)
        {
            var query = from urun in _context.Urunler
                        where urun.Active == true && urun.DepoId == depoId
                        select urun;
            return Task.Run(() => Pagination<Urunler>.Create(query.AsQueryable(), 1, 10));
        }
    }
}
