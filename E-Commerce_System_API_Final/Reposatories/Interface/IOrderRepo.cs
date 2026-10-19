using E_Commerce_System_API_Final.DTOs.OrderDTOs;
using E_Commerce_System_API_Final.Models;

namespace E_Commerce_System_API_Final.Reposatories.Interface
{
    public interface IOrderRepo : IGenericRepp<Order>
    {
        Task CreateOrderWithItsItems(CreateOrderWithItsItemsDTO DTO);
        Task<OrderDetailsDTO> GetOrderDetails(int orderid);
        Task<Order> PatchStatus(int  orderid, string status);
        Task<decimal> GetTotalRevenue();
    }
}
