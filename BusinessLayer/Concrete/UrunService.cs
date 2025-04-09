using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Migrations;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunService : IUrunService
    {
        private readonly IUrunlerDal urunlerDal;
        private readonly IMapper _mapper;
      
        public UrunService(IUrunlerDal urunlerDal, IMapper mapper)
        {
            _mapper = mapper;
            this.urunlerDal = urunlerDal;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                entity.Active = false;
                await Save(entity);
            }
        }
        //public async Task<List<Urunler>> GetAll()
        //{
        //    var items =  await urunlerDal.GetAll(3,4);
        //    items = items.Where(x => x.Active == true).ToList();
        //    return items;
        //}

        public async Task<Urunler> GetById(int id)
        {
            return await urunlerDal.GetById(id);
        }

        public async Task Save(Urunler entity)
        {
            if (entity.Id == 0)
            {
                await urunlerDal.Add(entity);

            }
            else
            {
                await urunlerDal.Edit(entity);
            }
        }

        //public async Task CreateStokRow(int id)
        //{
        //    Stok stok = new Stok();
        //    stok.UrunId = id;
        //    stok.StokMiktari = stok;
        //    stok.DepoId = depoid;
        //}

        //public async Task SaveUrun(UrunlerDto entity, int? insuserid)
        //{
        //    if (entity.Id == 0)
        //    {
        //        var item = _mapper.Map<Urunler>(entity);
        //        item.CreateDate = DateTime.Now;
        //        item.InsUserId = (int)insuserid;
        //        item.Approved = true;
        //        item.Active = true;
        //        await urunlerDal.Add(item);
        //    }
        //    else
        //    {
        //        var item = _mapper.Map<UrunlerDto, Urunler>(entity);
        //        await urunlerDal.Edit(item);
        //    }
        //}

        //public async Task<List<MusteriUrunDto>> GetAllMusteriUrunlDto()
        //{
        //    var products = await urunlerDal.GetAll();
        //    return _mapper.Map<List<MusteriUrunDto>>(products);
        //}

        public async Task<Pagination<UrunlerDto>> GetAllUrunlerDto(int pageIndex, int pageSize)
        {
            var items = await urunlerDal.GetAllUrunlerDto(pageIndex, pageSize);
            //var items = await urunlerDal.GetAll(pageIndex, pageSize);
            return items;
        }

        public async Task<Pagination<UrunlerDto>> GetByFilter(string marka, string adi, string barkod, string stok,string baslangicTarihi, string bitisTarihi , int pageIndex, int pageSize)
        {
            return await urunlerDal.GetByFilter(marka, adi, barkod, stok, baslangicTarihi, bitisTarihi, pageIndex, pageSize);
        }

        public byte[] GenerateTemplate()
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Urunler");
                worksheet.Column(3).Width = 30;
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
                    //worksheet.Cells[row, 1].Value = item.Marka;
                    worksheet.Cells[row, 2].Value = item.Adi;
                    worksheet.Cells[row, 3].Value = item.BarkodNo;
                    worksheet.Cells[row, 4].Value = item.Aciklama;
                    //worksheet.Cells[row, 5].Value = item.BirimId;
                    worksheet.Cells[row, 6].Value = item.AlisFiyat;
                    worksheet.Cells[row, 7].Value = item.SatisFiyat;
                    worksheet.Cells[row, 8].Value = item.Stok;
                    row++;
                }

                return package.GetAsByteArray();
            }
        }

        public async Task ImportFromExcelAsync(byte[] fileBytes,int userid)
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
                        //Marka = worksheet.Cells[row, 1].Text,
                        Adi = worksheet.Cells[row, 2].Text,
                        BarkodNo = worksheet.Cells[row, 3].Text,
                        Aciklama = worksheet.Cells[row, 4].Text,
                        //Birim = worksheet.Cells[row, 5].Text,
                        AlisFiyat = decimal.Parse(worksheet.Cells[row, 6].Text, CultureInfo.InvariantCulture),
                        SatisFiyat = decimal.Parse(worksheet.Cells[row, 7].Text, CultureInfo.InvariantCulture),
                        Stok = int.Parse(worksheet.Cells[row, 8].Text),
                        CreateDate = DateTime.Now,
                        InsUserId = userid,
                        Approved = true,
                        Active = true
                    };
                    items.Add(item);
                }
                await urunlerDal.BulkInsert(items);
            }
        }

        public Task<List<MusteriUrunDto>> GetAllMusteriUrunDto()
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<Urunler>> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Urunler> ConvertToEntity(UrunlerDto item)
        {
            return await Task.Run(() => _mapper.Map<Urunler>(item));
        }
    }
}
