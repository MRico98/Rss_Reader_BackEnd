using AutoMapper;
using Rss_Reader_BackEnd.Models;
using Rss_Reader_BackEnd.Models.Request;

namespace Rss_Reader_BackEnd.Profiles;

public class ItemProfile : Profile{
    public ItemProfile() {
        CreateMap<ItemRequest, Item>()
            .ForMember(
                dest => dest.CategoryItems, 
                opt => opt.MapFrom(
                    src => src.Categories.Select(
                        x => new CategoryItem { CategoryName = x})));
    }
}