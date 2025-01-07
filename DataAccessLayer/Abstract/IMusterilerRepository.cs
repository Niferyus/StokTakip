using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMusterilerRepository
    {
        List<Musteriler> GetAll();
        void Add(Musteriler m);
        void Update(int id);
        void Delete(int id);
        Musteriler GetById(int id);
    }
}
