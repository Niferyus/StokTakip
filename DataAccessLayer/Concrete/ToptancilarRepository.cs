using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ToptancilarRepository : IToptancilarRepository
    {
        void IToptancilarRepository.Ekle(Toptancilar toptanci)
        {
            throw new NotImplementedException();
        }

        void IToptancilarRepository.Guncelle(Toptancilar toptanci)
        {
            throw new NotImplementedException();
        }

        Toptancilar IToptancilarRepository.IDileGetir(int id)
        {
            throw new NotImplementedException();
        }

        List<Toptancilar> IToptancilarRepository.Listele()
        {
            throw new NotImplementedException();
        }

        void IToptancilarRepository.Sil(Toptancilar toptanci)
        {
            throw new NotImplementedException();
        }
    }
}
