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
    public class StokDal : GenericRepository<Stok>,IStokDal
    {
        public StokDal(Context context) : base(context)
        {
        }

        public async Task Create(List<Stok> stoks)
        {
            await _context.Stok.AddRangeAsync(stoks);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetDefaultDepo()
        {
            var item = await _context.Depo.FirstAsync(x => x.IsDefault == true);
            return item.Id;
        }

        public async Task<List<StokDto>> GetByUrunId(int id)
        {
            var query = from stok in _context.Stok
                        join depo in _context.Depo on stok.DepoId equals depo.Id
                        where stok.UrunId == id
                        select new StokDto
                        {
                            Id = stok.Id,
                            DepoName = depo.Ad,
                            StokMiktar = stok.StokMiktari,
                        };
           return await query.ToListAsync();
        }

        //public async Task StokGiris(int id)
        //{

        //}
    }
}
