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
    public class MarkaIdResolver : IValueResolver<UrunlerDto, Urunler, int>
    {
        private readonly IUrunlerDal _urunlerDal;

        public MarkaIdResolver(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }

        public int Resolve(UrunlerDto source, Urunler destination, int destMember, ResolutionContext context)
        {
            return _urunlerDal.GetMarkaId(source.MarkaAdi).Result;
        }
    }
}
