using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
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
        private readonly IKisiService toptancilarService;

        public IslemlerService(IIslemlerRepository islemlerRepository, IKisiService isoptancilarService, IUrunService urunlerService)
        {
            this.islemlerRepository = islemlerRepository;
            this.toptancilarService = isoptancilarService;
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
