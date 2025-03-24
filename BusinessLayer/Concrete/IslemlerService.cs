using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class IslemlerService : IIslemlerService
    {
        private readonly IIslemlerRepository islemlerRepository;
        private readonly IUrunService urunlerService;
        private readonly IToptancilarService toptancilarService;
        private readonly IMusterilerService musterilerService;

        public IslemlerService(IIslemlerRepository islemlerRepository, IToptancilarService isoptancilarService, IMusterilerService musterilerService, IUrunService urunlerService)
        {
            this.islemlerRepository = islemlerRepository;
            this.toptancilarService = isoptancilarService;
            this.musterilerService = musterilerService;
            this.urunlerService = urunlerService;
        }

        public void Add(Islemler islem)
        {
            islemlerRepository.Add(islem);
        }

        public void Delete(int id)
        {
            islemlerRepository.Delete(id);
        }

        public List<Islemler> GetAll()
        {
            return islemlerRepository.GetAll();
        }

        public List<IslemlerDto> GetAllDto()
        {
            return islemlerRepository.GetAllDtos();
        }

        public Islemler GetById(int id)
        {
            return islemlerRepository.GetById(id);
        }

        public void Update(Islemler islem)
        {
            islemlerRepository.Update(islem);
        }
    }
}
