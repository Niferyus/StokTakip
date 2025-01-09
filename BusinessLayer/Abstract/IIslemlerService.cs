using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IIslemlerService
    {
        List<Islemler> GetAll();
        List<IslemlerDto> GetAllDto();
        void Add(Islemler islem);
        void Update(Islemler islem);
        void Delete(int id);
        Islemler GetById(int id);
    }
}
