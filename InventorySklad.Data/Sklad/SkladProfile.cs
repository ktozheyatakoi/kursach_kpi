using AutoMapper;

namespace InventorySklad.Data.Sklad
{
    public class SkladDaoProfile : Profile
    {
        public SkladDaoProfile()
        {
            CreateMap<Core.Sklad.Sklad, SkladDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfItems, opt => opt.MapFrom(src => src.CountOfItems))
                .ReverseMap();

        }
    }
    public class DaoSkladProfile : Profile
    {
        public DaoSkladProfile()
        {
            CreateMap<Core.Sklad.Sklad, SkladDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfItems, opt => opt.MapFrom(src => src.CountOfItems))
                .ReverseMap();

        }
    }
}