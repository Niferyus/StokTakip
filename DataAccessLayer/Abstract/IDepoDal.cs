using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDepoDal:IGenericRepository<Depo>
    {
        public Task Edit(Depo entity);
        public Task<List<Yerlesim>> GetAllYerlesim (int id);
        public Task<Pagination<DepoDto>> GetAllDepo(int pageIndex, int pageSize);
    }
}
