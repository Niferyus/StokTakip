using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMusterilerService
    {
        List<Musteriler> Listele();
        void Ekle(Musteriler musteri);
        void Guncelle(Musteriler musteri);
        void Sil(Musteriler musteri);
        Musteriler IDileGetir(int id);
    }
}
