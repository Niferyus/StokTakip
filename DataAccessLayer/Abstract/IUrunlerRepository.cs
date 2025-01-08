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
        void Add(Urunler urun);
        void Update(Urunler urun);
        void Delete(int id);
        Urunler GetById(int id);
    }
}
