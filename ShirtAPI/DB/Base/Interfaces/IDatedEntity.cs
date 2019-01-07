using System;

namespace Poseidon.Domain.Models.Interfaces
{
    public interface IDatedEntity
    {
        DateTime Created { get; set; }
    }
}
