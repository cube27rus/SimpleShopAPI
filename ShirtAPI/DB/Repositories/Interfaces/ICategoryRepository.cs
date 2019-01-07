using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public interface ICategoryRepository : IEntityRepository<Category, int>
    {
    }
}