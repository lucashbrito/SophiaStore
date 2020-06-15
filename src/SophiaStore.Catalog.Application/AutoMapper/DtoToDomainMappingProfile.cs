using AutoMapper;
using SophiaStore.Catalog.Application.Dtos;
using SophiaStore.Catalog.Domain.Aggregate;

namespace SophiaStore.Catalog.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ConstructUsing(c => new Category(c.Name, c.Code));

            CreateMap<ProductDto, Product>()
                .ConstructUsing(p => new Product(
                    p.CategoryId, p.Name, p.Description, p.Active, p.Value, p.CreatedDate, p.Image, p.StockQuantity,
                    new Dimensions(p.Height, p.Width, p.Depth)));
        }
    }
}