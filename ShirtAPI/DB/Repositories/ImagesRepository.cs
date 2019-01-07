using ShirtAPI.DB.Base;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Repositories
{
    public class ImagesRepository : EntityBaseRepository<Image, int>, IImagesRepository
    {
        public ImagesRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
