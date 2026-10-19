namespace E_Commerce_System_API_Final.DTOs.OrderItemsDTOs
{
    public class OrderItemDTO
    {
        public int OrderItemID { get; set; }
        public int OrderItemQuantity { get; set; }
        public decimal OrderItemPrice { get; set; }
        public decimal TotalAmountOrderItem => OrderItemQuantity * OrderItemPrice;
    }
}
