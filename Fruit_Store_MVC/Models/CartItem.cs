namespace Fruit_Store_MVC.Models
{
    /// <summary>
    /// Represents a single item in the session-based shopping cart.
    /// Stored as JSON in ISession.
    /// </summary>
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }

        public decimal LineTotal => UnitPrice * Quantity;
    }
}
