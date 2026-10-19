using E_Commerce_System_API_Final.Data;
using E_Commerce_System_API_Final.DTOs.OrderDTOs;
using E_Commerce_System_API_Final.DTOs.OrderItemsDTOs;
using E_Commerce_System_API_Final.Models;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace E_Commerce_System_API_Final.Reposatories.Implmentation
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly AppDbContext _conext;
        public OrderRepo(AppDbContext context) : base(context)
        {
            _conext = context;
        }

        public async Task CreateOrderWithItsItems(CreateOrderWithItsItemsDTO DTO)
        {
            var order = new Order()
            {
                OrderDate = DTO.OrderDate,
                TotalAmount = DTO.TotalAmount,
                Status = DTO.Status,
                UserID = DTO.UserID,
                orderItems = new List<OrderItem>()
            };

           await _conext.orders.AddAsync(order);


           if(DTO.orderItemDTOs != null && DTO.orderItemDTOs.Any())
            {
                foreach(var item in DTO.orderItemDTOs)
                {
                    var orderitem = new OrderItem()
                    {
                     OrderID = item.OrderID,
                     ProductID = item.ProductID,
                     Quantity = item.Quantity,
                     UnitPrice = item.UnitPrice
                    };
                    order.orderItems.Add(orderitem);
                }
            }

            await _conext.SaveChangesAsync();
            
        }

        public async Task<OrderDetailsDTO> GetOrderDetails(int orderid)
        {
            var items = await _conext.orders
                .Include(s => s.orderItems)
                .Select(s => new OrderDetailsDTO
                {
                    OrderID = s.id,
                  
                    OrderDate = s.OrderDate,
                    Status = s.Status,
                    TotalAmount = s.TotalAmount,
                    UserID = s.UserID,

                    orderItemDTOs = s.orderItems.Select(n => new OrderItemDTO
                    {
                        OrderItemID = n.Id,
                        OrderItemPrice = n.UnitPrice,
                        OrderItemQuantity = n.Quantity,
                        

                    }).ToList(),

                     TotalAmountOrders = s.orderItems.Sum(s => s.Quantity* s.UnitPrice)


                }).FirstOrDefaultAsync(s => s.OrderID == orderid);

            return items;


        }

        public async Task<decimal> GetTotalRevenue()
        {
            return await _conext.orders.SumAsync(o => o.TotalAmount);
        }
        public Task<Order> PatchStatus(int orderid, string status)
        {
            throw new NotImplementedException();
        }
    }
}
