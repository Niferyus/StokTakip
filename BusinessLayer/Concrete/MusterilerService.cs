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
    public class MusterilerService : IMusterilerService
    {
        private readonly IMusterilerRepository musterilerRepository;

        public MusterilerService(IMusterilerRepository musterilerRepository)
        {
            this.musterilerRepository = musterilerRepository;
        }
        public void Add(Musteriler musteri)
        {
            musterilerRepository.Add(musteri);
        }

        public void Delete(int id)
        {
            musterilerRepository.Delete(id);
        }

        public List<Musteriler> GetAll()
        {
            return musterilerRepository.GetAll();
        }

        public Musteriler GetById(int id)
        {
            return musterilerRepository.GetById(id);
        }

        public void Update(Musteriler musteri)
        {
            musterilerRepository.Update(musteri); 
        }
    }
}
