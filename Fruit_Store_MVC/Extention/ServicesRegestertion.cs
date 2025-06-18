using Fruit_Store.Core.Interfaces.Services;
using Fruit_Store.Services.Services;

namespace Fruit_Store_MVC.Extention
{
    public static class ServicesRegestertion
    {
        public static IServiceCollection AddApplactionServices(this IServiceCollection services)
        {
            // Registering services for dependency injection
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderItemServices, OrderItemServices>();
            services.AddScoped<IReviewServices, ReviewServices>();
            services.AddScoped<ICouponServices, CouponServices>();
            services.AddScoped<INewServices, NewServices>();

            return services;
        }
    }
}
