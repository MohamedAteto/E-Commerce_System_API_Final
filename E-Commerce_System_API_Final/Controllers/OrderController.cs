using AutoMapper;
using E_Commerce_System_API_Final.DTOs.OrderDTOs;
using E_Commerce_System_API_Final.Mapping;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_System_API_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public OrderController(IUnitOfWork unit)
        {
            this.unit = unit;
            mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOrderWithItems(CreateOrderWithItsItemsDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Not Valid");

            await unit.orderRepo.CreateOrderWithItsItems(DTO);

            await unit.SaveChagnesAsync();
            return Ok(DTO);

        }

        [HttpGet("Get with Items")]
        public async Task<IActionResult> GetOrderWithitsItemsById(int oriderid)
        {
            var item = await unit.orderRepo.GetOrderDetails(oriderid);

            if (item is null)
                return BadRequest("Not Found");

            return Ok(item);
            
        }

        [HttpGet("Get TotlaRevenue")]
        public async Task<IActionResult> GetTotlaReveneu()
        {
            var item = await unit.orderRepo.GetTotalRevenue();

            return Ok(item);

        }
    }
}
