namespace Fruit_Store.Core.DTOs
{
    /// <summary>
    /// Lightweight DTO for passing cart items to the order creation service.
    /// Only contains ProductId and Quantity — prices are fetched from the DB server-side.
    /// </summary>
    public class CartItemForOrder
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
