using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Models.Interfaces;

namespace ShirtAPI.DB.Base.Interfaces
{
    public interface IEntity<IdType> : IDatedEntity
    {
        IdType Id { get; set; }
    }
}
