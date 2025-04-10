using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StokService : IStokService
    {
        private readonly IStokDal _stokDal;

        public StokService(IStokDal stokDal)
        {
            _stokDal = stokDal;
        }

        public async Task Create(List<Stok> stoks)
        {
            await _stokDal.Create(stoks);
        }

        public Task<int> GetDefaultDepo()
        {
            return _stokDal.GetDefaultDepo();
        }
    }
}
