using AutoMapper;

namespace InventorySklad.Orchestrators.Item
{
    public class OrchItemProfile : Profile
    {
        public OrchItemProfile()
        {
            CreateMap<Core.Item.Item, Item>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.InvNumber, opt => opt.MapFrom(src => src.InvNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ReverseMap();
        }
    }
    public class ItemOrchProfile : Profile
    {
        public ItemOrchProfile()
        {
            CreateMap<Core.Item.Item, Item>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.InvNumber, opt => opt.MapFrom(src => src.InvNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ReverseMap();
        }
    }
}