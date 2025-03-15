using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUrunlerRepository
    {
        List<Urunler> GetAll();

        List<MusteriUrunDto> GetAllDto();
        void Add(Urunler item);
        void Edit(Urunler item);
        void Delete(int id);
        Urunler GetById(int id);
        void AddList(List<Urunler> itemList);
        void saveChanges();
        Task<Pagination<Urunler>> GetByFilter(string marka, string adi, string barkod, string stok, int pageIndex, int pageSize);
        Task<List<Urunler>> GetAllAsync();
        Task AddAsync(List<Urunler> items);
        Task<Pagination<UrunlerDto>> GetAllUrunlerDto(int pageIndex, int pageSize);
    }
}
