using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IToptancilarService
    {
        List<Toptancilar> GetAll();

        List<ToptancilarDto> GetAllDto();
        void Add(Toptancilar toptanci);
        void Update(Toptancilar toptanci);
        void Delete(int id);
        Toptancilar GetById(int? id);
    }
}
