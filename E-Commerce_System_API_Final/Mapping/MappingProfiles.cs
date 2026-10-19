using AutoMapper;
using E_Commerce_System_API_Final.DTOs.AuthDTOs;
using E_Commerce_System_API_Final.DTOs.CategoryDTOs;
using E_Commerce_System_API_Final.DTOs.ProductDTOs;
using E_Commerce_System_API_Final.Models;

namespace E_Commerce_System_API_Final.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<User, Login>().ReverseMap();
            CreateMap<User, Register>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();








// new change in the git hub 
        }
    }
}
