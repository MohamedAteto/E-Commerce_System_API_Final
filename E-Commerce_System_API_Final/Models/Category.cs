using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System_API_Final.Models
{
    [Index(nameof(Name) , IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(200 , MinimumLength =2)] 
        
        public string Name { get; set; }

        [Required, MaxLength(200)]

        public string Description { get; set; }

        public ICollection<Product> products { get; set; } = new List<Product>();

    }
}
