using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.InkML;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void Add(Urunler item)
        {
            context.Urunler.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            StringBuilder stringbuild = new StringBuilder();
            var item = GetById(id);
            if (item != null)
            {
                context.Urunler.Remove(item);
                stringbuild.Append(item.Adi);
                stringbuild.Append("satıldı");
                Console.WriteLine(stringbuild.ToString());
                Console.WriteLine($"{item.Adi} adlı ürün silindi");
                context.SaveChanges();
            }
        }

        public List<Urunler> GetAll()
        {
            var item = context.Urunler.FromSqlRaw("EXEC GetAllUrunler").ToList();
            //var list = context.Urunler.Where(c => c.Approved == true).ToList();
            //list.ForEach(urun => urun.UrunFiyat = urun.UrunFiyat*10/100 + urun.UrunFiyat);
            return item;
        }

        public List<MusteriUrunDto> GetAllDto()
        {
            var query = from urun in context.Urunler
                        select new MusteriUrunDto
                        {
                            UrunId = urun.Id,
                            UrunAdi = urun.Adi,
                            UrunFiyati = urun.SatisFiyat,
                            UrunStok = urun.Stok
                        };
            return query.ToList();
        }

        public Urunler GetById(int id)
        {
            //var item = context.Urunler.FromSqlInterpolated($"EXEC GetById @URUNID = {id}").FirstOrDefault();
            //return item;
            return context.Urunler.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Urunler item)
        {
            var existingEntity = context.Urunler.Find(item.Id);
            if (existingEntity != null)
            {
                context.Entry(existingEntity).CurrentValues.SetValues(item); // Mevcut veriyi güncelle
                context.SaveChanges();
            }
        }

        public void UpdatePrice(int id, int kdv)
        {
            //İNSERT UPDATE DELETE STORED PROCEDURELER İÇİN ExecuteSqlRaw kullanılır
            context.Database.ExecuteSqlRaw($"EXEC UpdateUrun @URUNID = {id}, @KDV = {kdv} ");
        }

        public async void AddList(List<Urunler> itemList)
        {
            context.Urunler.AddRange(itemList);
            //context.SaveChanges();
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the error (uncomment ex variable name and write a log.)
                Console.WriteLine($"An error occurred while saving the entity changes: {ex.Message}");
                throw;
            }
        }

        public void saveChanges()
        {
            context.SaveChanges();
        }

        public List<Urunler> GetByFilter(string marka, string adi, string barkod, string stok)
        {
            var query = context.Urunler.AsQueryable();

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

            return query.ToList();
        }
    }
}
