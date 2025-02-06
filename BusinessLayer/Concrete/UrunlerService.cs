using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
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

        public List<Urunler> GetByFilter(string marka, string adi, string barkod, string stok)
        {
            return urunlerRepository.GetByFilter(marka, adi, barkod, stok);
        }
    }
}
