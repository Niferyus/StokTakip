using AutoMapper;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class IlceAdResolver : IValueResolver<Depo, DepoDto, string>
    {
        private readonly IDepoDal _depoDal;

        public IlceAdResolver(IDepoDal depoDal)
        {
            _depoDal = depoDal;
        }

        public string Resolve(Depo source, DepoDto destination, string destMember, ResolutionContext context)
        {
            return _depoDal.GetIlceNameById(source.IlceId).Result;
        }
    }
}
