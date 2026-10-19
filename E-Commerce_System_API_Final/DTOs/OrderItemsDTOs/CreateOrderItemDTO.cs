using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce_System_API_Final.Models;

namespace E_Commerce_System_API_Final.DTOs.OrderItemsDTOs
{
    public class CreateOrderItemDTO
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public decimal TotalItemsAmount => UnitPrice * Quantity;
    }
}
