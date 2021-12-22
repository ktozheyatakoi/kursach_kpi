using AutoMapper;

namespace InventorySklad.Orchestrators.Sklad
{
    public class SkladOrchProfile : Profile
    {
        public SkladOrchProfile()
        {
            CreateMap<Core.Sklad.Sklad, Sklad>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfItems, opt => opt.MapFrom(src => src.CountOfItems))
                .ReverseMap();

        }
    }
    public class OrchSkladProfile : Profile
    {
        public OrchSkladProfile()
        {
            CreateMap<Core.Sklad.Sklad, Sklad>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfItems, opt => opt.MapFrom(src => src.CountOfItems))
                .ReverseMap();

        }
    }
}