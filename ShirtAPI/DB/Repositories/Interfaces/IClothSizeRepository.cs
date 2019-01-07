using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public interface IClothSizeRepository : IEntityRepository<ClothSize, int>
    {
    }
}