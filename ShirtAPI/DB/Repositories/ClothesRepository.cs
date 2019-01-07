using Poseidon.Domain.Repositories.Interfaces;
using ShirtAPI.DB;
using ShirtAPI.DB.Base;
using ShirtAPI.Models;

namespace Poseidon.Domain.Repositories
{
    public class ClothesRepository : EntityBaseRepository<Clothes, int>, IClothesRepository
    {
        public ClothesRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
