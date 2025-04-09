using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Bibliography;
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
                        //join marka in _context.Marka on urun.MarkaId equals marka.Id
                        //join birim in _context.Birim on urun.BirimId equals birim.Id
                        where urun.Active == true
                        select new UrunlerDto
                        {
                            Id = urun.Id,
                            UserName = user.Name,
                            //  MarkaAdi = marka.Ad,
                            Adi = urun.Adi,
                            BarkodNo = urun.BarkodNo,
                            Aciklama = urun.Aciklama,
                            //Birim = birim.Ad,
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
                        //join markaa in _context.Marka on urun.MarkaId equals markaa.Id
                        //join birim in _context.Birim on urun.BirimId equals birim.Id
                        where urun.Active == true
                        select new UrunlerDto
                        {
                            Id = urun.Id,
                            UserName = user.Name,
                            //  MarkaAdi = markaa.Ad,
                            Adi = urun.Adi,
                            BarkodNo = urun.BarkodNo,
                            Aciklama = urun.Aciklama,
                            //Birim = birim.Ad,
                            AlisFiyat = urun.AlisFiyat,
                            SatisFiyat = urun.SatisFiyat,
                            Stok = urun.Stok,
                            Tarih = urun.CreateDate
                        };


            if (!string.IsNullOrEmpty(marka))
                query = query.Where(x => x.MarkaAdi.Contains(marka));

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

        //public Task<Pagination<Urunler>> GetDepoUrunler(int depoId)
        //{
        //    var query = from urun in _context.Urunler
        //                where urun.Active == true && urun.DepoId == depoId
        //                select urun;
        //    return Task.Run(() => Pagination<Urunler>.Create(query.AsQueryable(), 1, 10));
        //}

        public async Task<int> GetIdByName<TEntity>(string name) where TEntity : class
        {
            var entity = await _context.Set<TEntity>()
                .Where(x => EF.Property<string>(x, "Ad") == name) // Burada EF.Property kullanıyoruz.
                .Select(x => EF.Property<int>(x, "Id")) // Burada da EF.Property kullanıyoruz.
                .FirstOrDefaultAsync();

            if (entity == 0) // FirstOrDefaultAsync() int döndürdüğü için null yerine 0 kontrolü yapıyoruz.
                throw new InvalidOperationException($"(ID: {entity}) BULUNAMADI");

            return entity;
        }

        public async Task<string> GetNameById<TEntity>(int id) where TEntity : class
        {
            var name = await _context.Set<TEntity>()
                .Where(x => EF.Property<int>(x, "Id") == id) // Burada EF.Property kullanıyoruz.
                .Select(x => EF.Property<string>(x, "Ad")) // Burada da EF.Property kullanıyoruz.
                .FirstOrDefaultAsync();

            if (name == null)
                throw new InvalidOperationException($"(ID: {name}) BULUNAMADI");

            return (string)name;
        }

        public async Task<int> GetMarkaId(string markaAdi)
        {
            return await GetIdByName<Marka>(markaAdi);
        }

        public async Task<int> GetBirimId(string birimAdi)
        {
            return await GetIdByName<Birim>(birimAdi);
        }

        public async Task<int> GetDepoId(string depoAdi)
        {
            return await GetIdByName<Depo>(depoAdi);
        }

        public async Task<string> GetMarkaName(int id)
        {
            return await GetNameById<Marka>(id);
        }

        public async Task<string> GetBirimName(int id)
        {
            return await GetNameById<Birim>(id);
        }

        public async Task<string> GetDepoName(int id)
        {
            return await GetNameById<Depo>(id);
        }
    }
}
