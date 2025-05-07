using DataAccessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHareketlerDal : IGenericRepository<Hareketler>
    {
        public Task<Pagination<HareketlerDto>> GetAllDto(int pageIndex, int pageSize);
    }
}
