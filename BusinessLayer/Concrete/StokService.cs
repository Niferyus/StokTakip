using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
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
        private readonly IMapper _mapper;

        public StokService(IStokDal stokDal, IMapper mapper)
        {
            _stokDal = stokDal;
            _mapper = mapper;
        }

        public async Task Create(List<Stok> stoks)
        {
            await _stokDal.Create(stoks);
        }

        public Task<int> GetDefaultDepo()
        {
            return _stokDal.GetDefaultDepo();
        }

        public async Task<List<StokDto>> GetByUrunId(int id)
        {
            return await _stokDal.GetByUrunId(id);
        }

        public async Task<bool> StokGiris(int id, int miktar)
        {
            var item = await _stokDal.GetById(id);
            if(item == null)
            {
                return false;
            }
            else
            {
                item.StokMiktari = miktar;
                await _stokDal.Update(item);
                return true;
            }
            
        }
    }
}
