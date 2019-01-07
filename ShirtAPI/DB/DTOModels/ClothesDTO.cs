using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtAPI.Models;

namespace ShirtAPI.DB.DTOModels
{
    public class ClothesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Image> Images { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public Type Type { get; set; }
        public int TypeId { get; set; }
        public List<ClothSize> Sizes { get; set; }
    }
}
