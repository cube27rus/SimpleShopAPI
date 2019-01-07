﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShirtAPI.DB.DTOModels
{
    public class SelectedClothesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string TypeName { get; set; }
        public string Size { get; set; }
    }
}
