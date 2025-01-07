using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMusterilerService
    {
        List<Musteriler> GetAll();
        void Add(Musteriler musteri);
        void Update(int id);
        void Delete(int id);
        Musteriler GetById(int id);
    }
}
