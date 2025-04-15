using DataAccessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDepoDal:IGenericRepository<Depo>
    {
        public Task Edit(Depo entity);
        public Task<List<Yerlesim>> GetAllYerlesim (int id);
        public Task<Pagination<DepoDto>> GetAllDepo(int pageIndex, int pageSize);
        public Task<List<Depo>> GetDefaultntDepo();
        public Task<int> GetSehirIdByName(string sehirAdi);
        public Task<int> GetIlceIdByName(string ilceAdi);
        public Task<string> GetIlceNameById(int ilceId);
        public Task<string> GetSehirNameById(int sehirId);        
    }
}
