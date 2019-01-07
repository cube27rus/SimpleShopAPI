using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtAPI.DB.Base;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public class SizeRepository : EntityBaseRepository<Size, int>, ISizeRepository
    {
        public SizeRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
