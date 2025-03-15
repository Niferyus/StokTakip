using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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
        public Task<Pagination<Urunler>> GetDepoUrunler(int depoId);
    }
}
