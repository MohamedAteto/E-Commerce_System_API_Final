using System.ComponentModel.DataAnnotations;
using E_Commerce_System_API_Final.DTOs.OrderItemsDTOs;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace E_Commerce_System_API_Final.DTOs.OrderDTOs
{
    public class OrderDetailsDTO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public int UserID { get; set; }

        public decimal TotalAmountOrders { get; set; }
        public ICollection<OrderItemDTO> orderItemDTOs { get; set; }

    }
}
