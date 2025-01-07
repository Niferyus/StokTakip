using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunlerService
    {
        private readonly IUrunlerRepository urunlerRepository;

        public UrunlerService(IUrunlerRepository urunlerRepository)
        {
            this.urunlerRepository = urunlerRepository;
        }

        public List<Urunler> Listele()
        {
            return urunlerRepository.Listele();
        }
    }
}
