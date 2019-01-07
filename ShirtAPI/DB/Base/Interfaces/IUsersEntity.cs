using Poseidon.Domain.Models.Interfaces;
using ShirtAPI.DB.Base.Interfaces;

namespace Poseidon.Domain.Models.Interfaces
{
    public interface IUsersEntity: IEntity<int>
    {
        int UserId { get; set; }
    }
}
