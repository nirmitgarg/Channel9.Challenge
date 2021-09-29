using AutoMapper;
using Channel9.Challenge.Dto;
using Channel9.Challenge.Models;

namespace Channel9.Challenge.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommercialBreak, OptimizedCommercialBreak>();
            CreateMap<BreakCommercial, BreakCommercialInfo>()
                .ForMember(dest => dest.Demography, opt => opt.MapFrom(src => src.Demography.ToString()))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
        }
    }
}
