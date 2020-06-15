using System.Threading.Tasks;

namespace SophiaStore.Core.Data
{
    public interface IUnitOfWork
    {
        public Task<bool> Commit();

    }
}