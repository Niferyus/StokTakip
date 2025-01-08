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
    public class ToptancilarService : IToptancilarService
    {
        private readonly IToptancilarRepository toptancilarRepository;

        public ToptancilarService(IToptancilarRepository toptancilarRepository)
        {
            this.toptancilarRepository = toptancilarRepository;
        }

        public void Add(Toptancilar toptanci)
        {
            toptancilarRepository.Add(toptanci);
        }

        public void Delete(int id)
        {
            toptancilarRepository.Delete(id);
        }

        public List<Toptancilar> GetAll()
        {
            return toptancilarRepository.GetAll();
        }

        public Toptancilar GetById(int id)
        {
            return toptancilarRepository.GetById(id);
        }

        public void Update(Toptancilar toptanci)
        {
            toptancilarRepository.Update(toptanci);
        }
    }
}
