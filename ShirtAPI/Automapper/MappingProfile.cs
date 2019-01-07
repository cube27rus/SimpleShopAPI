using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShirtAPI.DB.DTOModels;
using ShirtAPI.DB.Models;
using ShirtAPI.Models;

namespace ShirtAPI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<OrderDTO, Order>();
            CreateMap<ClothesDTO, Clothes>();
            CreateMap<Clothes, ClothesDTO>();
        }
    }
}
