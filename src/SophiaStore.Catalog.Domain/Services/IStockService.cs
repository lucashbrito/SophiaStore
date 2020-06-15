using System;
using System.Threading.Tasks;

namespace SophiaStore.Catalog.Domain.Services
{
    public interface IStockService:IDisposable
    {
        Task<bool> Debit(Guid productId, int quantity);
        Task<bool> Replace(Guid productId, int quantity);
    }
}