using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public interface IImagesRepository : IEntityRepository<Image, int>
    {
    }
}