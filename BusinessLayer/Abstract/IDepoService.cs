using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDepoService:IGenericService<Depo>
    {
        public Task<Pagination<Urunler>> GetDepoUrunler(int depoId, int pageIndex, int pageSize);
        public Task<List<Yerlesim>> GetAllYerlesim(int id);
        public Task<Pagination<DepoDto>> GetAllDepo(int pageIndex, int pageSize);
        public Task<Depo> ConvertToEntity(DepoDto dto);
    }
}
