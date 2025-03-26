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

            CreateMap<UrunlerDto, Urunler>()
                .ForMember(dest => dest.MarkaId, opt => opt.MapFrom<MarkaIdResolver>())
                .ForMember(dest => dest.BirimId, opt => opt.MapFrom<BirimIdResolver>())
                //.ForMember(dest => dest.DepoId, opt => opt.MapFrom<DepoIdResolver>())
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.Tarih))
                .ReverseMap()
                .ForMember(dest => dest.MarkaAdi, opt => opt.MapFrom<MarkaAdResolver>())
                .ForMember(dest => dest.Birim, opt => opt.MapFrom<BirimAdResolver>());
                //.ForMember(dest => dest.DepoAdi, opt => opt.MapFrom<DepoAdResolver>());


            CreateMap<Pagination<Depo>, Pagination<DepoDto>>()
                .ReverseMap();
        }
    }
}
