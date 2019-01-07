using Poseidon.Domain.Models;
using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.Models;

namespace Poseidon.Domain.Repositories.Interfaces
{
    public interface IClothesRepository : IEntityRepository<Clothes, int>
    {
    }
}
