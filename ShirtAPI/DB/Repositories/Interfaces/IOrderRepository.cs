using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.DB.Models;

namespace ShirtAPI.DB.Repositories
{
    public interface IOrderRepository : IEntityRepository<Order, int>
    {
    }
}