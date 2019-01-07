using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poseidon.Domain.Data;
using ShirtAPI.DB.Models;
using ShirtAPI.Models;
using ShirtAPI.Services;

namespace ShirtAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public OrdersController(IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveOrder([FromBody]OrderDTO order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await EmailService.SendOrderMail(order);

                var result = Mapper.Map<Order>(order);
                await UnitOfWork.OrderRepository.AddAsync(result);
                await UnitOfWork.CommitAsync();

                foreach (var cloth in order.ClothesList)
                {
                    await UnitOfWork.OrderClothRepository.AddAsync(new OrderCloth()
                    {
                        OrderId = result.Id,
                        ClothesId = cloth.Id
                    });
                }

                await UnitOfWork.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}