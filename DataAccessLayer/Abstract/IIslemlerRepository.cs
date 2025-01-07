using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IIslemlerRepository
    {
        public List<Islemler> Listele();
        public void Ekle(Islemler islem);
        public void Guncelle(Islemler islem);
        public void Sil(Islemler islem);
        public Islemler IDileGetir(int id);
    }
}
