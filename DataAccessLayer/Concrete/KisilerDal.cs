using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class KisilerDal : GenericRepository<Kisiler>, IKisilerDal
    {
        public KisilerDal(Context context) : base(context)
        {
        }


        public async Task<int> GetIdByName<TEntity>(string name) where TEntity : class
        {
            var entity = await _context.Set<TEntity>()
                .Where(x => EF.Property<string>(x, "Ad") == name) // Burada EF.Property kullanıyoruz.
                .Select(x => EF.Property<int>(x, "Id")) // Burada da EF.Property kullanıyoruz.
                .FirstOrDefaultAsync();

            if (entity == 0) // FirstOrDefaultAsync() int döndürdüğü için null yerine 0 kontrolü yapıyoruz.
                throw new InvalidOperationException($"(ID: {entity}) BULUNAMADI");

            return entity;
        }

        public async Task<int> GetkisiId(string name)
        {
            return await GetIdByName<Kisiler>(name);
        }
    }
}
