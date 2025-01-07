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
        public List<Islemler> GetAll();
        public void Add(Islemler islem);
        public void Update(int id);
        public void Delete(int id);
        public Islemler GetById(int id);
    }
}
