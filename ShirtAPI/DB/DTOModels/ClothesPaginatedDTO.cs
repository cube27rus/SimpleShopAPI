using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShirtAPI.DB.DTOModels
{
    public class ClothesPaginatedDTO
    {
        public List<ClothesDTO> Clothes { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }

    }
}
