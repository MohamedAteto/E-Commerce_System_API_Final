namespace E_Commerce_System_API_Final.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQantity { get; set; }
        public int CategoryID { get; set; }
    }
}
