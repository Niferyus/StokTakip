using DataAccessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHareketlerService : IGenericService<Hareketler>
    {
        public Task<Pagination<HareketlerDto>> GetAllDto(int pageIndex, int pageSize);
    }
}
