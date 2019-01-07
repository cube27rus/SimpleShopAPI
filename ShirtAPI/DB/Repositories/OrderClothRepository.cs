using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtAPI.DB.Base;
using ShirtAPI.DB.Models;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public class OrderClothRepository : EntityBaseRepository<OrderCloth, int>, IOrderClothRepository
    {
        public OrderClothRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
