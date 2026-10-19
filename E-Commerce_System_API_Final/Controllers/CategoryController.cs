using AutoMapper;
using E_Commerce_System_API_Final.DTOs.CategoryDTOs;
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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public CategoryController(IUnitOfWork unit)
        {
            this.unit = unit;
            mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await unit.CategoryRepo.GetAll();

            if (items is null)
                return BadRequest("Not Found");

            var DTO = mapper.Map<List<CategoryDTO>>(items);

            return Ok(DTO);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategoryDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Not Valid");

            var Entity = mapper.Map<Category>(DTO);

            await unit.CategoryRepo.Create(Entity);
            await unit.SaveChagnesAsync();

            return Ok("Created Succefully");
        }



    }
}
