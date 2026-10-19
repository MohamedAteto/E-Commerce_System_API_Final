using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_System_API_Final.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required,StringLength(100 , MinimumLength = 2)]
        public string Name {  get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required,Range(0.01,100000)]
        public decimal Price { get; set; }
        [Required, Range(0.01, 100000)]
        public int StockQantity { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }



        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
