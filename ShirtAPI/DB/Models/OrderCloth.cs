﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Domain.Models.Base;
using ShirtAPI.DB.Base.Interfaces;
using ShirtAPI.Models;

namespace ShirtAPI.DB.Models
{
    public class OrderCloth : EntityBase<int>, IEntity<int>
    {
        public Clothes Clothes { get; set; }
        public int ClothesId { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
