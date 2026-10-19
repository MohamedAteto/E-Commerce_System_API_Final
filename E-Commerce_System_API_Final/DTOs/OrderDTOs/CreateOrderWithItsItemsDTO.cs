using System.ComponentModel.DataAnnotations;
using E_Commerce_System_API_Final.DTOs.OrderItemsDTOs;

namespace E_Commerce_System_API_Final.DTOs.OrderDTOs
{
    public class CreateOrderWithItsItemsDTO
    {
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserID { get; set; }

        public ICollection<CreateOrderItemDTO> orderItemDTOs { get; set; }
    }
}
