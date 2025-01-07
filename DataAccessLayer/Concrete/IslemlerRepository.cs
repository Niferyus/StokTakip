using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class IslemlerRepository : IIslemlerRepository
    {
        private readonly Context context;

        public IslemlerRepository(Context context)
        {
            context = context;
        }

        public void Add(Islemler islem)
        {
            context.Islemler.Add(islem);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var islem = GetById(id);
            if (islem != null)
            {
                context.Islemler.Remove(islem);
                context.SaveChanges();
            }
        }

        public List<Islemler> GetAll()
        {
            return context.Islemler.ToList();
        }

        public Islemler GetById(int id)
        {
            return context.Islemler.FirstOrDefault(x => x.IslemlerID == id);
        }

        public void Update(int id)
        {
            var islem = GetById(id);
            if (islem != null)
            {
                context.Islemler.Update(islem);
                context.SaveChanges();
            }
        }
    }
}
