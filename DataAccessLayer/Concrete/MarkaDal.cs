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
    public class MarkaDal:GenericRepository<Marka>,IMarkaDal
    {
        public MarkaDal(Context context) : base(context)
        {
        }

        public async Task<List<Marka>> GetAllMarka()
        {
            return await _context.Marka.Where(x => x.IsActive == true).ToListAsync();
        }
    }
}
