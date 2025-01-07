using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IToptancilarRepository
    {
        List<Toptancilar> GetAll();
        void Add(Toptancilar toptanci);
        void Update(int id);
        void Delete(int id);
        Toptancilar GetById(int id);
    }
}
