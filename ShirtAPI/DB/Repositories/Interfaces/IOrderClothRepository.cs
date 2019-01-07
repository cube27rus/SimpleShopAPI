using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.DB.Models;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public interface IOrderClothRepository : IEntityRepository<OrderCloth, int>
    {
    }
}