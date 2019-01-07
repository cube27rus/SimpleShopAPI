using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Repositories.Base.Interfaces;
using ShirtAPI.Models;
using Type = ShirtAPI.Models.Type;

namespace ShirtAPI.DB.Repositories.Interfaces
{
    interface ITypeRepository : IEntityRepository<Type, int>
    {
    }
}
