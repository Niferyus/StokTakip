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

            //CreateMap<Depo, DepoDto>().ReverseMap();

            CreateMap<DepoDto, Depo>()
                .ForMember(dest => dest.SehirId, opt => opt.MapFrom<SehirIdResolver>())
                .ForMember(dest => dest.IlceId, opt => opt.MapFrom<IlceIdResolver>())
                .ForMember(dest => dest.Urunler, opt => opt.Ignore())
                .ForMember(dest => dest.InsUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.Approved, opt => opt.Ignore())
                .ForMember(dest => dest.Active, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Sehir, opt => opt.MapFrom<SehirAdResolver>())
                .ForMember(dest => dest.Ilce, opt => opt.MapFrom<IlceAdResolver>());

            CreateMap<Pagination<Depo>, Pagination<DepoDto>>()
                .ReverseMap();
        }
    }
}
