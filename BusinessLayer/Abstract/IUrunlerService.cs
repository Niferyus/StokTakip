using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUrunlerService
    {
        List<Urunler> GetAll();

        List<MusteriUrunDto> GetAllDto();
        void Add(Urunler urun);
        void Update(Urunler urun);
        void Delete(int id);
        Urunler GetById(int id);
    }
}
