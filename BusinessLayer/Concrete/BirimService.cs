using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BirimService : IBirimService
    {
        private readonly IBirimDal _birimDal;

        public BirimService(IBirimDal birimDal)
        {
            _birimDal = birimDal;
        }

        public async Task Delete(int id)
        {
            var item = await _birimDal.GetById(id);
            if (item != null)
            {
                item.IsActive = false;
                await Save(item);
            }
        }

        public Task<Pagination<Birim>> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Birim>> GetAllBirim()
        {
            return await _birimDal.GetAllBirim();
        }

        public async Task<Birim> GetById(int id)
        {
            return await _birimDal.GetById(id);
        }

        public async Task Save(Birim entity)
        {
            if (entity.Id == 0)
            {
                await _birimDal.Add(entity);
            }
            else
            {
                await _birimDal.Update(entity);
            }
        }
    }
}
