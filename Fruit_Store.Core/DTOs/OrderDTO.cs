using FruitStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.DTOs
{
    class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;

        // Foreign Keys
        public int? CouponId { get; set; }
    }
}
