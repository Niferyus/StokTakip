using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UrunlerRepository : IUrunlerRepository
    {
        void IUrunlerRepository.Ekle(Urunler urun)
        {
            throw new NotImplementedException();
        }

        void IUrunlerRepository.Guncelle(Urunler urun)
        {
            throw new NotImplementedException();
        }

        Urunler IUrunlerRepository.IDileGetir(int id)
        {
            throw new NotImplementedException();
        }

        List<Urunler> IUrunlerRepository.Listele()
        {
            throw new NotImplementedException();
        }

        void IUrunlerRepository.Sil(Urunler urun)
        {
            throw new NotImplementedException();
        }
    }
}
