using AutoMapper;
using E_Commerce_System_API_Final.DTOs.CategoryDTOs;
using E_Commerce_System_API_Final.DTOs.ProductDTOs;
using E_Commerce_System_API_Final.Mapping;
using E_Commerce_System_API_Final.Models;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_System_API_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork unit)
        {
            this.unit = unit;
            mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithPagignation()
        {
            var items = await unit.productRepo.GetAll();

            if (items is null)
                return BadRequest("Not Found");

            var DTO = mapper.Map<List<ProductDTO>>(items);

            return Ok(DTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id )
        {
            var items = await unit.productRepo.GetByID(id);

            if (items is null)
                return BadRequest("Not Found");

            var DTO = mapper.Map<ProductDTO>(items);

            return Ok(DTO);
        }

        [HttpGet("Secondmost Expensive")]
        public async Task<IActionResult> GetSecondmost(int id)
        {
            var items = await unit.productRepo.GetSecondMostExpensiveProductInACategory(id);

            if (items is null)
                return BadRequest("Not Found");

            var DTO = mapper.Map<List<ProductDTO>>(items);

            return Ok(DTO);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateProductDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Not Valid");

            var Entity = mapper.Map<Product>(DTO);

            await unit.productRepo.Create(Entity);
            await unit.SaveChagnesAsync();

            return Ok("Created Succefully");
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id,UpdateProductDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Not Valid");

            var item = await unit.productRepo.GetByID(id);
            if (item is null)
                return BadRequest("item not found");

            mapper.Map(DTO, item);

            await unit.productRepo.Update(id ,item);
            await unit.SaveChagnesAsync();

            return Ok("updated Succefully");
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchStock(int id,int StockQuanity)
        {

            var item = await unit.productRepo.GetByID(id);
            if (item is null)
                return BadRequest("item not found");

            item.StockQantity = StockQuanity;
            await unit.productRepo.Update(id, item);
            await unit.SaveChagnesAsync();
            return Ok("updated Succefully");

        }

        [HttpGet("By Name")]
        public async Task<IActionResult> GetByName(string Name)
        {
            var items = await unit.productRepo.GetProductByName(Name);

            if (items is null)
                return BadRequest("Not Found");

            var DTO = mapper.Map<List<ProductDTO>>(items);

            return Ok(DTO);
        }


    }
}
