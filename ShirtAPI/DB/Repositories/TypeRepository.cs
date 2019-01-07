
using ShirtAPI.DB.Base;
using ShirtAPI.DB.Repositories.Interfaces;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public class TypeRepository : EntityBaseRepository<Type, int>, ITypeRepository
    {
        public TypeRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
