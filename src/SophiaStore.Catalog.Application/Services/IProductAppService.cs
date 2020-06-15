using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SophiaStore.Catalog.Application.Dtos;

namespace SophiaStore.Catalog.Application.Services
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(Guid id);
        Task<IEnumerable<ProductDto>> GetByCategoryCode(int code);
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task Add(ProductDto product);
        Task Update(ProductDto product);
        Task AddCategory(CategoryDto category);
        Task UpdateCategory(CategoryDto category);

        Task<ProductDto> Debit(Guid productId, int quantity);
        Task<ProductDto> Replace(Guid productId, int quantity);
    }
}
