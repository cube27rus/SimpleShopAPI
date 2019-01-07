using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Poseidon.Domain.Models.Base;
using ShirtAPI.DB.Base.Interfaces;

namespace ShirtAPI.Models
{
    public class Clothes : EntityBase<int>, IEntity<int>
    {
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
