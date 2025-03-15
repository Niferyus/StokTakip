using AutoMapper;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Urunler, MusteriUrunDto>()
                .ForMember(dest => dest.Fiyat, opt => opt.MapFrom(src => src.SatisFiyat))
                .ReverseMap();

            CreateMap<Urunler, UrunlerDto>()
                .ForMember(dest => dest.Tarih, opt => opt.MapFrom(src => src.CreateDate))
                .ReverseMap();

            CreateMap<Depo, DepoDto>().ReverseMap();

            CreateMap<Pagination<Depo>, Pagination<DepoDto>>()
                .ReverseMap();
        }
    }
}
