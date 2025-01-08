using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunlerService:IUrunlerService
    {
        private readonly IUrunlerRepository urunlerRepository;

        public UrunlerService(IUrunlerRepository urunlerRepository)
        {
            this.urunlerRepository = urunlerRepository;
        }

        public void Add(Urunler urun)
        {
            urunlerRepository.Add(urun);
        }

        public void Delete(int id)
        {
            urunlerRepository.Delete(id);
        }

        public List<Urunler> GetAll()
        {
            return urunlerRepository.GetAll();
        }

        public Urunler GetById(int id)
        {
            return urunlerRepository.GetById(id);
        }

        public void Update(Urunler urun)
        {
            urunlerRepository.Update(urun);
        }
    }
}
