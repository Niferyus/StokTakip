using EntityLayer.Concrete.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUrunOzellikDal:IGenericRepository<UrunOzellikleri>
    {
        public Task<List<UrunOzellikleri>> GetAllOzellik(string type);
    }
}
