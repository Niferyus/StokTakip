using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Mapping;
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
    public class DepoService : IDepoService
    {
        private readonly IDepoDal _depoDal;
        private readonly IUrunlerDal _urunlerDal;
        private readonly IMapper _mapper;

        public DepoService(IDepoDal depoDal, IUrunlerDal urunlerDal, IMapper mapper)
        {
            _depoDal = depoDal;
            _urunlerDal = urunlerDal;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var entity = await _depoDal.GetById(id);
            if (entity != null)
            {
                entity.Active = false;
                await Save(entity);
            }
        }

        public async Task<Pagination<Depo>> GetAll(int pageIndex, int pageSize)
        {
            var items = await _depoDal.GetAll(pageIndex, pageSize);
            items.items = items.items.Where(x => x.Active == true).ToList();
            return items;
        }

        public async Task<Depo> GetById(int id)
        {
            return await _depoDal.GetById(id);
        }

        public async Task Save(Depo entity)
        {
            if (entity.Id == 0)
            {
                await _depoDal.Add(entity);
            }
            else
            {
                var item = await _depoDal.GetById(entity.Id);
                entity.CreateDate = item.CreateDate;
                entity.Approved = item.Approved;
                entity.InsUserId = item.InsUserId;
                entity.Active = item.Active;
                await _depoDal.Edit(entity);
            }
        }

        //public async Task<Pagination<Urunler>> GetDepoUrunler(int depoId, int pageIndex, int pageSize)
        //{
        //    var items = await _urunlerDal.GetDepoUrunler(depoId);
        //    return items;
        //}

        public async Task<List<Yerlesim>> GetAllYerlesim(int id)
        {
            return await _depoDal.GetAllYerlesim(id);
        }

        public async Task<Pagination<DepoDto>> GetAllDepo(int pageIndex, int pageSize)
        {
            return await _depoDal.GetAllDepo(pageIndex, pageSize);
        }

        public async Task<Depo> ConvertToEntity(DepoDto item)
        {
            return await Task.Run(() => _mapper.Map<Depo>(item));
        }
    }
}
