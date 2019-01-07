using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Repositories.Interfaces;
using ShirtAPI.DB.Base;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public class CategoryRepository : EntityBaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
