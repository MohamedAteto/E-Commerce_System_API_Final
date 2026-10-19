using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using E_Commerce_System_API_Final.DTOs.AuthDTOs;
using E_Commerce_System_API_Final.Mapping;
using E_Commerce_System_API_Final.Models;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce_System_API_Final.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public AuthController(IUnitOfWork unit, IConfiguration config)
        {
            this.unit = unit;
            mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
            this.config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register DTO)
        {
            if (DTO is null)
                return BadRequest("Not Valid");

            var item = await unit.userRepo.GetUserByUserName(DTO.FullName);
            if (item != null)
                return BadRequest("Already exist");

            var Entity = mapper.Map<User>(DTO);

            await unit.userRepo.Create(Entity);
            await unit.SaveChagnesAsync();

            return Ok("Added Succfullly");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login (Login DTO)
        {
            if (DTO is null)
                return BadRequest("Not Valid");

            var item = await unit.userRepo.GetUserByUserName(DTO.FullName);
            if (item is null)
                return BadRequest(" Not exist");

            var Token = GenerateToken(item);
            return Ok(Token);
        }

        private string GenerateToken(User user)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier , user.id.ToString() ),
                new Claim(ClaimTypes.Name , user.FullName),
                new Claim(ClaimTypes.Role , user.Role)

            };

            var Token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds,
                claims : claims
            );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }


    }
}
