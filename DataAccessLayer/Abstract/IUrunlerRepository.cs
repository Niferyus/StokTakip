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
        List<Urunler> GetByFilter(string marka, string adi, string barkod, string stok);
    }
}
