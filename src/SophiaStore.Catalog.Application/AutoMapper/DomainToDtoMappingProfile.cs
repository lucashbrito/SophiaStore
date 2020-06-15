using AutoMapper;
using SophiaStore.Catalog.Application.Dtos;
using SophiaStore.Catalog.Domain.Aggregate;

namespace SophiaStore.Catalog.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Height, o => o.MapFrom(s => s.Dimensions.Height))
                .ForMember(d => d.Width, o => o.MapFrom(s => s.Dimensions.Width))
                .ForMember(d => d.Depth, o => o.MapFrom(s => s.Dimensions.Depth));
        }
    }
}
