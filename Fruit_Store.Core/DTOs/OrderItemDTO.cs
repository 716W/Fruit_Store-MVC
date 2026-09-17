using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; } // Primary Key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Foreign Keys
        public int OrderId { get; set; } // foreign key for Order
        public int ProductId { get; set; } // foreign key for Product
        public string? ProductName { get; set; }
    }
}
