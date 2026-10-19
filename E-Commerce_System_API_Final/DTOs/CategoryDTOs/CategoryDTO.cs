using System.ComponentModel.DataAnnotations;

namespace E_Commerce_System_API_Final.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }
    }
}
