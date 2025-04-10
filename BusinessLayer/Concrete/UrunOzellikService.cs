using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunOzellikService : IUrunOzellikService
    {
        private readonly IUrunOzellikDal _urunOzellikDal;

        public UrunOzellikService(IUrunOzellikDal urunOzellikDal)
        {
            _urunOzellikDal = urunOzellikDal;
        }

        public async Task Delete(int id)
        {
           await _urunOzellikDal.Delete(id);
        }

        public Task<Pagination<UrunOzellikleri>> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UrunOzellikleri>> GetAllOzellik(string type)
        {
           return await _urunOzellikDal.GetAllOzellik(type);
        }

        public async Task<UrunOzellikleri> GetById(int id)
        {
            return await _urunOzellikDal.GetById(id);
        }

        public async Task Save(UrunOzellikleri entity)
        {
            if(entity.Id == 0)
            {
                await _urunOzellikDal.Add(entity);
            }
            else
            {
                await _urunOzellikDal.Update(entity);
            }
        }
    }
}
