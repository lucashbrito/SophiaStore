using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SophiaStore.Catalog.Domain.Aggregate;
using SophiaStore.Core.Data;
using SophiaStore.Core.Messages;

namespace SophiaStore.Catalog.Data
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = SetAllStringTypeToVarchar(modelBuilder);

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        private static ModelBuilder SetAllStringTypeToVarchar(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            return modelBuilder;
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
