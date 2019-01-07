using System;
using Poseidon.Domain.Models.Interfaces;
using ShirtAPI.DB.Base.Interfaces;

namespace Poseidon.Domain.Models.Base
{
    public abstract class EntityBase<IdType> : IEntity<IdType>
    {
        public IdType Id { get; set; }
        public DateTime Created { get; set; }
    }
}
