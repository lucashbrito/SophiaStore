using System;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
