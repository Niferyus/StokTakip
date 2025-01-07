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
    public class IslemlerService : IIslemlerService
    {
        private readonly IIslemlerRepository islemlerRepository;

        public IslemlerService(IIslemlerRepository islemlerRepository)
        {
            this.islemlerRepository = islemlerRepository;
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

        public Islemler GetById(int id)
        {
            return islemlerRepository.GetById(id);
        }

        public void Update(int id)
        {
            islemlerRepository.Update(id);
        }
    }
}
