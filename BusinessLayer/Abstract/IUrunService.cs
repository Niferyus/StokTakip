using DataAccessLayer.Concrete;
using EntityLayer.Class;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUrunService : IGenericService<Urunler>
    {
        public Task<List<MusteriUrunDto>> GetAllMusteriUrunDto();
        public Task<Pagination<UrunlerDto>> GetAllUrunlerDto(int pageIndex, int pageSize);
        public Task<Pagination<UrunlerDto>> GetByFilter(ProductFilter filter,int pageIndex, int pageSize);
        public byte[] GenerateTemplate();
        public byte[] ExportToExcel(List<Urunler> items);
        public Task ImportFromExcelAsync(byte[] fileBytes,int userid);
        public Task<Urunler> ConvertToEntity(UrunlerDto item);
        public Task<int> GeturunId(string name);
        public Task<Urunler?> GetByBarcode(string barcode);

        //public Task SaveUrun(UrunlerDto entity, int? insuserid);
    }
}
