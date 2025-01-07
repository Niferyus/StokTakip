using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class IslemlerRepository : IIslemlerRepository
    {
        private readonly Context _context;

        public IslemlerRepository(Context context)
        {
            _context = context;
        }
        void IIslemlerRepository.Ekle(Islemler islem)
        {
            _context.Islemler.Add(islem);
            _context.Islemler.Add(islem);
            _context.SaveChanges();
        }

        void IIslemlerRepository.Guncelle(Islemler islem)
        {
            throw new NotImplementedException();
        }

        Islemler IIslemlerRepository.IDileGetir(int id)
        {
            throw new NotImplementedException();
        }

        List<Islemler> IIslemlerRepository.Listele()
        {
            throw new NotImplementedException();
        }

        void IIslemlerRepository.Sil(Islemler islem)
        {
            throw new NotImplementedException();
        }
    }
}
