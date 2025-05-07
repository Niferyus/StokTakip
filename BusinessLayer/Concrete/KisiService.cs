using AutoMapper;
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
    public class KisiService : IKisiService
    {
        private readonly IKisilerDal _kisiDal;
        private readonly IMapper _mapper;

        public KisiService(IKisilerDal kisiDal, IMapper mapper)
        {
            _kisiDal = kisiDal;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _kisiDal.Delete(id);
        }

        public async Task<Pagination<Kisiler>> GetAll(int pageIndex, int pageSize)
        {
           return await _kisiDal.GetAll(pageIndex, pageSize);
        }

        public async Task<int> GetkisiId(string name)
        {
            return await _kisiDal.GetkisiId(name);
        }
        public async Task<List<Kisiler>> GetAllDefault()
        {
            return await _kisiDal.GetAllDefault();
        }

        public async Task<Pagination<KisilerDto>> GetAllDto(int pageIndex, int pageSize)
        {
            var items = await GetAll(pageIndex,pageSize);
            return _mapper.Map<Pagination<KisilerDto>>(items);
        }

        public async Task<Kisiler> GetById(int id)
        {
            return await _kisiDal.GetById(id);
        }

        public async Task Save(Kisiler entity)
        {
            if(entity.Id == 0)
            {
                await _kisiDal.Add(entity);
            }
            else
            {
                await _kisiDal.Update(entity);
            }
        }
    }
}
