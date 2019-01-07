using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Models.Base;
using ShirtAPI.DB.Base.Interfaces;

namespace ShirtAPI.Models
{
    public class Size : EntityBase<int>, IEntity<int>
    {
        public string SizeName { get; set; }
        public virtual ICollection<ClothSize> Clothes { get; set; }
    }
}
