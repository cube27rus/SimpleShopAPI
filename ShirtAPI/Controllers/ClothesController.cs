using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poseidon.Domain.Data;
using ShirtAPI.DB.DTOModels;
using ShirtAPI.Models;

namespace ShirtAPI.Controllers
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClothesController : Controller
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }
        private int PageSize = 9;

        public ClothesController(IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClothes()
        {
            try
            {
                var result = (await UnitOfWork.ClothesRepository.GetAllAsync())
                                .Include(x => x.Images)
                                .Include(x => x.Category)
                                .Include(x => x.Type)
                                .Include(x => x.Sizes)
                                .ThenInclude(x => x.Size)
                                .Select(x => Mapper.Map<ClothesDTO>(x))
                                .ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("all/{page}")]
        public async Task<IActionResult> GetAllClothesPaginated(int page = 1)
        {
            try
            {
                IQueryable<Clothes> source = (await UnitOfWork.ClothesRepository.GetAllAsync())
                    .Include(x => x.Images)
                    .Include(x => x.Category)
                    .Include(x => x.Type)
                    .Include(x => x.Sizes)
                    .ThenInclude(x => x.Size);
                var count = await source.CountAsync();
                var items = await source
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .Select(x => Mapper.Map<ClothesDTO>(x))
                    .ToListAsync();

                var result = new ClothesPaginatedDTO()
                {
                    Clothes = items,
                    Count = count,
                    Page = page

                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("category/{category}/{page}")]
        public async Task<IActionResult> GetClothesByCategoryPaginated(string category,int page = 1)
        {
            try
            {
                IQueryable<Clothes> source = (await UnitOfWork.ClothesRepository.FindByAsync(x => x.Category.EngName == category))
                                                .Include(x => x.Images)
                                                .Include(x => x.Category)
                                                .Include(x => x.Type)
                                                .Include(x => x.Sizes)
                                                .ThenInclude(x => x.Size);
                var count = await source.CountAsync();
                var items = await source
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .Select(x => Mapper.Map<ClothesDTO>(x))
                    .ToListAsync();

                var result = new ClothesPaginatedDTO()
                {
                    Clothes = items,
                    Count = count,
                    Page = page

                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}