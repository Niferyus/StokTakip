using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
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

    }
}
