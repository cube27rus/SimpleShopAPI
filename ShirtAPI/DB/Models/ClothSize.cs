using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Models.Base;
using ShirtAPI.DB.Base.Interfaces;

namespace ShirtAPI.Models
{
    public class ClothSize : EntityBase<int>, IEntity<int>
    {
        public Clothes Clothes { get; set; }
        public int ClothesId { get; set; }

        public Size Size { get; set; }
        public int SizeId { get; set; }
    }
}
