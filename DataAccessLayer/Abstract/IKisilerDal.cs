using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IKisilerDal : IGenericRepository<Kisiler>
    {
        public Task<int> GetkisiId(string name);
    }
}
