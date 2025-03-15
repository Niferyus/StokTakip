using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunlerService : IUrunlerService
    {
        private readonly IUrunlerRepository urunlerRepository;

        public UrunlerService(IUrunlerRepository urunlerRepository)
        {
            this.urunlerRepository = urunlerRepository;
        }

        public void Delete(int id)
        {
            urunlerRepository.Delete(id);
        }

        public List<Urunler> GetAll()
        {
            return urunlerRepository.GetAll();
        }

        public List<MusteriUrunDto> GetAllDto()
        {
            return urunlerRepository.GetAllDto();
        }

        public Urunler GetById(int id)
        {
            return urunlerRepository.GetById(id);
        }

        public void Save(Urunler entity)
        {
            if (entity != null && entity.Id > 0)
            {
                urunlerRepository.Edit(entity);
            }
            else {
                urunlerRepository.Add(entity);
            }
            
        }

        public void Add(Urunler item)
        {
            urunlerRepository.Add(item);
        }
        public void Edit(Urunler item)
        {
            urunlerRepository.Edit(item);
        }

        public async void AddList(List<Urunler> itemList)
        {
            urunlerRepository.AddList(itemList);
            urunlerRepository.saveChanges();
        }

        public void saveChanges()
        {
            urunlerRepository.saveChanges();
        }

        public async Task<Pagination<Urunler>> GetByFilter(string marka, string adi, string barkod, string stok, int pageIndex, int pageSize)
        {
            return await urunlerRepository.GetByFilter(marka, adi, barkod, stok,pageIndex,pageSize);
        }

        public async Task<List<Urunler>> GetAllAsync()
        { 
            return await urunlerRepository.GetAllAsync();
        }

        public async Task ImportFromExcelAsync(byte[] fileBytes)
        {
            using (var stream = new MemoryStream(fileBytes))
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                var items = new List<Urunler>();
                for (int row = 2; row <= rowCount; row++)
                {
                    var item = new Urunler
                    {
                        Marka = worksheet.Cells[row, 1].Text,
                        Adi = worksheet.Cells[row, 2].Text,
                        BarkodNo = worksheet.Cells[row, 3].Text,
                        Aciklama = worksheet.Cells[row, 4].Text,
                        Birim = worksheet.Cells[row, 5].Text,
                        AlisFiyat = decimal.Parse(worksheet.Cells[row, 6].Text, CultureInfo.InvariantCulture),
                        SatisFiyat = decimal.Parse(worksheet.Cells[row, 7].Text, CultureInfo.InvariantCulture),
                        Stok = int.Parse(worksheet.Cells[row, 8].Text),
                        CreateDate = DateTime.Now,
                        //InsUserId = S,
                        Approved = true,
                        Active = true
                    }; // bulk ınsert
                    items.Add(item);
                }

                await urunlerRepository.AddAsync(items);
            }
        }

        public byte[] GenerateTemplate()
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Urunler");
                worksheet.Cells[1, 1].Value = "Marka";
                worksheet.Cells[1, 2].Value = "Adi";
                worksheet.Cells[1, 3].Value = "BarkodNo";
                worksheet.Cells[1, 4].Value = "Aciklama";
                worksheet.Cells[1, 5].Value = "Birim";
                worksheet.Cells[1, 6].Value = "AlisFiyat";
                worksheet.Cells[1, 7].Value = "SatisFiyat";
                worksheet.Cells[1, 8].Value = "Stok";

                return package.GetAsByteArray();
            }
        }

        public byte[] ExportToExcel(List<Urunler> items)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Urunler");
                worksheet.Cells[1, 1].Value = "Marka";
                worksheet.Cells[1, 2].Value = "Adi";
                worksheet.Cells[1, 3].Value = "BarkodNo";
                worksheet.Cells[1, 4].Value = "Aciklama";
                worksheet.Cells[1, 5].Value = "Birim";
                worksheet.Cells[1, 6].Value = "AlisFiyat";
                worksheet.Cells[1, 7].Value = "SatisFiyat";
                worksheet.Cells[1, 8].Value = "Stok";

                int row = 2;
                foreach (var item in items)
                {
                    worksheet.Cells[row, 1].Value = item.Marka;
                    worksheet.Cells[row, 2].Value = item.Adi;
                    worksheet.Cells[row, 3].Value = item.BarkodNo;
                    worksheet.Cells[row, 4].Value = item.Aciklama;
                    worksheet.Cells[row, 5].Value = item.Birim;
                    worksheet.Cells[row, 6].Value = item.AlisFiyat;
                    worksheet.Cells[row, 7].Value = item.SatisFiyat;
                    worksheet.Cells[row, 8].Value = item.Stok;
                    row++;
                }

                return package.GetAsByteArray();
            }
        }

        public Task<Pagination<UrunlerDto>> GetAllUrunlerDto(int pageIndex, int pageSize)
        {
            var items = urunlerRepository.GetAllUrunlerDto(pageIndex, pageSize);
            return items;
        }
    }
}
