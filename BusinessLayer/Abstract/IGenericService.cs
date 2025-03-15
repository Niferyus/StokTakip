using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<Pagination<T>> GetAll(int pageIndex,int pageSize);
        Task<T> GetById(int id);
        Task Save(T entity);
        Task Delete(int id);
    }
}
