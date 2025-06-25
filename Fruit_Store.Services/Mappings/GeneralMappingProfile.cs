using AutoMapper;
using FruitStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fruit_Store.Core.DTOs;

namespace Fruit_Store.Services.Mappings
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            // -- All My Mapping here --//

            // For products
            CreateMap<Product, ProductDTO>().ReverseMap();

            // For order items
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

            // For categories
            CreateMap<Category, CategoryDTO>().ReverseMap();

            // For reviews
            CreateMap<Review, ReviewDTO>().ReverseMap();

            // For orders
            CreateMap<Order, OrderDTO>().ReverseMap();

            // For Coupons
            CreateMap<Coupon, CouponDTO>().ReverseMap();

            // For News
            CreateMap<New, NewDTO>().ReverseMap();
        }
    }
}
