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
    public class BirimDal : GenericRepository<Birim>, IBirimDal
    {
        public BirimDal(Context context) : base(context)
        {
        }

        public async Task<List<Birim>> GetAllBirim()
        {
            return await _context.Birim.Where(x => x.IsActive == true).ToListAsync();
        }
    }
}
