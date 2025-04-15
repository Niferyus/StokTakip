using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStokService
    {
        public Task Create(List<Stok> stoks);
        public Task<int> GetDefaultDepo();
        public Task<List<StokDto>> GetByUrunId(int id);
        public Task<bool> StokGiris(int id, int miktar);
    }
}
