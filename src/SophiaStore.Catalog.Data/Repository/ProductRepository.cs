using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SophiaStore.Catalog.Domain;
using SophiaStore.Catalog.Domain.Aggregate;
using SophiaStore.Core.Data;

namespace SophiaStore.Catalog.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Product.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetByCategoryCode(int code)
        {
            return await _context.Product.AsNoTracking().Include(p => p.Category)
                .Where(c => c.Category.Code == code).ToListAsync(); ;
        }

        public async Task<IEnumerable<Product>> GetAllCategories()
        {
            return await _context.Product.AsNoTracking().ToListAsync();
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);
        }

        public void Update(Product product)
        {
            _context.Product.Update(product);
        }

        public void Add(Category category)
        {
            _context.Category.Add(category);
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
