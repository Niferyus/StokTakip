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
        List<Urunler> Listele();
        void Ekle(Urunler urun);
        void Guncelle(Urunler urun);
        void Sil(Urunler urun);
        Urunler IDileGetir(int id);
    }
}
