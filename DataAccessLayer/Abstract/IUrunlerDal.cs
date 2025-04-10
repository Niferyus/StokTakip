using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUrunlerDal : IGenericRepository<Urunler>
    {
        public Task<Pagination<UrunlerDto>> GetAllUrunlerDto(int pageIndex, int pageSize);
        public Task<Pagination<UrunlerDto>> GetByFilter(string marka, string adi, string barkod, string stok, string baslangicTarihi, string bitisTarihi, int pageIndex, int pageSize);
        public Task BulkInsert(List<Urunler> items);
        public Task Edit(Urunler entity);
        //public Task<Pagination<Urunler>> GetDepoUrunler(int depoId);
        public Task<int> GetMarkaId(string markaAdi);
        public Task<int> GetBirimId(string birimAdi);
        public Task<int> GetDepoId(string depoAdi);
        public Task<string> GetMarkaName(int id);
        public Task<string> GetBirimName(int id);
        public Task<string> GetDepoName(int id);   
    }
}
