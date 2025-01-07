using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IIslemlerService
    {
        List<Islemler> Listele();
        void Ekle(Islemler islem);
        void Guncelle(Islemler islem);
        void Sil(Islemler islem);
        Islemler IDileGetir(int id);
    }
}
