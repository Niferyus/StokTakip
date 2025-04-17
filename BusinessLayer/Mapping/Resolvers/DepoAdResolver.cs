using AutoMapper;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping.Resolvers
{
    public class DepoAdResolver  /*IValueResolver<Urunler, UrunlerDto, string>*/
    {
        private readonly IUrunlerDal _urunlerDal;

        public DepoAdResolver(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }

        //public string Resolve(Urunler source, UrunlerDto destination, string destMember, ResolutionContext context)
        //{
        //    return _urunlerDal.GetDepoName((int)source.DepoId).Result;
        //}
    }
}
