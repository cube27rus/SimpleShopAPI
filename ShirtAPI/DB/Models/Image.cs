using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Models.Base;
using ShirtAPI.DB.Base.Interfaces;

namespace ShirtAPI.Models
{
    public class Image : EntityBase<int>, IEntity<int>
    {
        public Clothes Clothes { get; set; }
        public int ClothesId { get; set; }
        public string Path { get; set; }
        public string Alt { get; set; }
    }
}
