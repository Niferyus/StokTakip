using AutoMapper;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping.Resolvers
{
    public class BirimIdResolver : IValueResolver<UrunlerDto, Urunler, int>
    {
        private readonly IUrunlerDal _urunlerDal;

        public BirimIdResolver(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }

        public int Resolve(UrunlerDto source, Urunler destination, int destMember, ResolutionContext context)
        {
            return _urunlerDal.GetBirimId(source.BirimAdi).Result;
        }
    }
}
