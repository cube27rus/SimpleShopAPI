using Poseidon.Domain.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using Poseidon.Domain.Repositories;
using ShirtAPI.DB.Repositories;

namespace Poseidon.Domain.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();

        #region Repositories
        IClothesRepository ClothesRepository { get; }
        IImagesRepository ImagesRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IClothSizeRepository ClothSizeRepository { get; }
        ISizeRepository SizeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderClothRepository OrderClothRepository { get; }
        #endregion
    }
}
