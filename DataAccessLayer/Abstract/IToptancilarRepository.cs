using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IToptancilarRepository
    {
        List<Toptancilar> Listele();
        void Ekle(Toptancilar toptanci);
        void Guncelle(Toptancilar toptanci);
        void Sil(Toptancilar toptanci);
        Toptancilar IDileGetir(int id);
    }
}
