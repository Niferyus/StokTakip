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
        List<Urunler> Listele();
        void Ekle(Urunler urun);
        void Guncelle(Urunler urun);
        void Sil(Urunler urun);
        Urunler IDileGetir(int id);
    }
}
