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
    public class MarkaService : IMarkaService
    {
        private readonly IMarkaDal _markaDal;

        public MarkaService(IMarkaDal markaDal)
        {
            _markaDal = markaDal;
        }

        public async Task Delete(int id)
        {
            var item = await _markaDal.GetById(id);
            if (item != null)
            {
                item.IsActive = false;
                await Save(item);
            }
        }

        public Task<Pagination<Marka>> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Marka>> GetAllMarka()
        {
            return await _markaDal.GetAllMarka();
        }

        public async Task<Marka> GetById(int id)
        {
            var marka = await _markaDal.GetById(id);
            return marka;
        }

        public async Task Save(Marka entity)
        {
            if (entity.Id == 0)
            {
                await _markaDal.Add(entity);
            }
            else
            {
                await _markaDal.Update(entity);
            }
        }
    }
}
