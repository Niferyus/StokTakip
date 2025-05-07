using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HareketlerService : IHareketlerService
    {
        private readonly IHareketlerDal _hareketDal;

        public HareketlerService(IHareketlerDal hareketDal)
        {
            _hareketDal = hareketDal;
        }

        public async Task Delete(int id)
        {
            await _hareketDal.Delete(id);
        }

        public async Task<Pagination<Hareketler>> GetAll(int pageIndex, int pageSize)
        {
            return await _hareketDal.GetAll(pageIndex, pageSize);
        }

        public Task<List<Hareketler>> GetAllDefault()
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<HareketlerDto>> GetAllDto(int pageIndex, int pageSize)
        {
            return await _hareketDal.GetAllDto(pageIndex, pageSize);
        }

        public async Task<Hareketler> GetById(int id)
        {
            return await _hareketDal.GetById(id);
        }

        public async Task Save(Hareketler entity)
        {
            if (entity.Id == 0)
            {
                await _hareketDal.Add(entity);

            }
            else
            {
                await _hareketDal.Update(entity);
            }
        }

    }
}
