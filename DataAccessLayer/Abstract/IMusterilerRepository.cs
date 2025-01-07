using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMusterilerRepository
    {
        List<Musteriler> Listele();
        void Ekle(Musteriler m);
        void Guncelle(Musteriler m);
        void Sil(Musteriler m);
        Musteriler IDileGetir(int id);
    }
}
