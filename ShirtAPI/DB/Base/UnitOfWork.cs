using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Poseidon.Domain.Models.Base;
using Poseidon.Domain.Models.Interfaces;
using Poseidon.Domain.Repositories;
using Poseidon.Domain.Repositories.Interfaces;
using ShirtAPI.DB;
using ShirtAPI.DB.Repositories;

namespace Poseidon.Domain.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationContext DbContext { get; }

        #region Repositories
        public IClothesRepository ClothesRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IImagesRepository ImagesRepository { get; }
        public IClothSizeRepository ClothSizeRepository { get; }
        public ISizeRepository SizeRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderClothRepository OrderClothRepository { get; }
        #endregion

        public UnitOfWork(ApplicationContext dbContext,
            IClothesRepository clothesRepository,
            IImagesRepository imagesRepository, 
            ICategoryRepository categoryRepository, 
            IClothSizeRepository clothSizeRepository, 
            ISizeRepository sizeRepository, 
            IOrderRepository orderRepository, 
            IOrderClothRepository orderClothRepository)
        {
            DbContext = dbContext;
            ClothesRepository = clothesRepository;
            ImagesRepository = imagesRepository;
            CategoryRepository = categoryRepository;
            ClothSizeRepository = clothSizeRepository;
            SizeRepository = sizeRepository;
            OrderRepository = orderRepository;
            OrderClothRepository = orderClothRepository;
        }

        public bool Commit()
        {
            UpdateDates();
            return (DbContext.SaveChanges()) > 0;
        }

        public async Task<bool> CommitAsync()
        {
            UpdateDates();
            return (await DbContext.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        private void UpdateDates()
        {
            var entityBaseType = typeof(EntityBase<int>);
            var entries = DbContext.ChangeTracker.Entries()
                .Where(w => w.Entity.GetType().BaseType.Namespace == entityBaseType.Namespace)
                .ToList();

            foreach (EntityEntry entry in entries)
            {
                var updatedEntity = entry.Entity as IDatedEntity;
                
                switch (entry.State)
                {
                    case EntityState.Modified:
                        var originalValueOfEntityCreated = entry.OriginalValues.GetValue<DateTime>("Created");
                        updatedEntity.Created = originalValueOfEntityCreated;
                        break;
                    case EntityState.Added:
                        updatedEntity.Created = DateTime.Now;
                        break;
                }

            }
        }
    }
}
