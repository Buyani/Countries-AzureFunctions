using AutoMapper;
using palota_func_countries_assessment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace palota_func_countries_assessment.Helpers
{
    public static class Mappings
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                //maps API attributes to custom attributes
                cfg.CreateMap<Country, CountryViewModel>()
                .ForMember(dest => dest.flag, act => act.MapFrom(src => src.flags.svg))
                .ForMember(dest => dest.name, act => act.MapFrom(src => src.name.common))
                .ForMember(dest => dest.iso3Code, act => act.MapFrom(src => src.cca3))
                .ForMember(dest => dest.numericCode, act => act.MapFrom(src => src.ccn3))
                .ForMember(dest => dest.capital, act => act.MapFrom(src => src.capital[0]))
                .ForMember(dest => dest.nativeName, act => act.MapFrom(src => src.name.nativeName.eng.common))
                .ForMember(dest => dest.demonym, act => act.MapFrom(src => src.demonyms.eng.f))
                .ForMember(dest => dest.location, act => act.MapFrom(src => 
                new Location { lattitude = src.latlng[0], longitude = src.latlng[1] }));

            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
