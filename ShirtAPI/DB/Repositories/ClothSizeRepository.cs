using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtAPI.DB.Base;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public class ClothSizeRepository : EntityBaseRepository<ClothSize, int>, IClothSizeRepository
    {
        public ClothSizeRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
