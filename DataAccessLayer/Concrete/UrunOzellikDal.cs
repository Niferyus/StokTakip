using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UrunOzellikDal : GenericRepository<UrunOzellikleri>, IUrunOzellikDal
    {
        public UrunOzellikDal(Context context) : base(context)
        {
        }

        public async Task<List<UrunOzellikleri>> GetAllOzellik(string type)
        {
            return await _context.UrunOzellikleri
                         .Where(x => x.type == type)
                         .ToListAsync();
        }
    }
}
