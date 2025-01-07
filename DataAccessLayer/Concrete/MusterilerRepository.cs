using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class MusterilerRepository : IMusterilerRepository
    {
        private readonly Context context;

        public MusterilerRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Musteriler m)
        {
            context.Musteriler.Add(m);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var musteri = GetById(id);
            if (musteri != null)
            {
                context.Musteriler.Remove(musteri);
                context.SaveChanges();
            }
        }

        public List<Musteriler> GetAll()
        {
            return context.Musteriler.ToList();
        }

        public Musteriler GetById(int id)
        {
            return context.Musteriler.FirstOrDefault(x => x.MusteriID == id);
        }

        public void Update(int id)
        {
            var musteri = GetById(id);
            if (musteri != null)
            {
                context.Musteriler.Update(musteri);
                context.SaveChanges();
            }
        }
    }
}
