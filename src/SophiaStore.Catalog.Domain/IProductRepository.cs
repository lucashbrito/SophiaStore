using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SophiaStore.Catalog.Domain.Aggregate;
using SophiaStore.Core.Data;

namespace SophiaStore.Catalog.Domain
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetByCategoryCode(int code);
        Task<IEnumerable<Product>> GetAllCategories();
        void Add(Product product);
        void Update(Product product);
        void Add(Category category);
        void Update(Category category);

    }
}
