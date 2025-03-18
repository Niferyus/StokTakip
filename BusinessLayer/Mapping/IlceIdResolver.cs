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
    public class IlceIdResolver : IValueResolver<DepoDto, Depo, int>
    {
        private readonly IDepoDal _depoDal;

        public IlceIdResolver(IDepoDal depoDal)
        {
            _depoDal = depoDal;
        }

        public int Resolve(DepoDto source, Depo destination, int destMember, ResolutionContext context)
        {
            return _depoDal.GetIlceIdByName(source.Ilce).Result;
        }
    }
}
