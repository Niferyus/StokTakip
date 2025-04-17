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
    public class SehirAdResolver : IValueResolver<Depo, DepoDto, string>
    {
        private readonly IDepoDal _depoDal;

        public SehirAdResolver(IDepoDal depoDal)
        {
            _depoDal = depoDal;
        }

        public string Resolve(Depo source, DepoDto destination, string destMember, ResolutionContext context)
        {
            return _depoDal.GetSehirNameById(source.SehirId).Result;
        }
    }
}
