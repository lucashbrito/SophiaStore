using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SophiaStore.Sales.Application.Queries.Dtos;

namespace SophiaStore.Sales.Application.Queries
{
    public interface IOrderQueries
    {
        Task<CatDto> GetCatClient(Guid clientId);

        Task<IEnumerable<OrderDto>> GetOrdersClient(Guid clientID);
    }
}
