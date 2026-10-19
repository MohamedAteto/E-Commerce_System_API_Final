using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_System_API_Final.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }


        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User user { get; set; }


        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();

    }
}
