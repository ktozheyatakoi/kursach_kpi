using AutoMapper;

namespace InventorySklad.Data.Item
{
    public class DaoItemProfile : Profile
    {
        public DaoItemProfile()
        {
            CreateMap<Core.Item.Item, ItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.InvNumber, opt => opt.MapFrom(src => src.InvNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ReverseMap();
        }
    }
    public class ItemDaoProfile : Profile
    {
        public ItemDaoProfile()
        {
            CreateMap<Core.Item.Item, ItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.InvNumber, opt => opt.MapFrom(src => src.InvNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ReverseMap();
        }
    }
}