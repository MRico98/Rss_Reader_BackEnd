using AutoMapper;
using Rss_Reader_BackEnd.Models;
using Rss_Reader_BackEnd.Models.Request;

namespace Rss_Reader_BackEnd.Profiles;

public class CategoryItemProfile : Profile {
    public CategoryItemProfile() {
        /*
        CreateMap<Item, List<CategoryItem>>()
            .ForMember(dest => dest, opt => opt.MapFrom(src => src..Select(x => new CategoryItem {  })));
            */
    }
}