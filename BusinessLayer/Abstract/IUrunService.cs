using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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
        public Task<Pagination<UrunlerDto>> GetByFilter(string marka, string adi, string barkod, string stok, string baslangicTarihi, string bitisTarihi, int pageIndex, int pageSize);
        public byte[] GenerateTemplate();
        public byte[] ExportToExcel(List<Urunler> items);
        public Task ImportFromExcelAsync(byte[] fileBytes,int userid);
        public Task<Urunler> ConvertToEntity(UrunlerDto item);

        //public Task SaveUrun(UrunlerDto entity, int? insuserid);
    }
}
