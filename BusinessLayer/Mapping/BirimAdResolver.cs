using AutoMapper;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class BirimAdResolver : IValueResolver<Urunler, UrunlerDto, string>
    {
        private readonly IUrunlerDal _urunlerDal;

        public BirimAdResolver(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }

        public string Resolve(Urunler source, UrunlerDto destination, string destMember, ResolutionContext context)
        {
            return _urunlerDal.GetBirimName((int)source.BirimId).Result;
        }
    }
}
