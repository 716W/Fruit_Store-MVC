using System.Reflection;
using Fruit_Store_MVC.Areas.Admin.Controllers;
using FruitStore.MVC.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Fruit_Store.Tests
{
    public class SecurityAndAuthorizationTests
    {
        [Theory]
        [InlineData(typeof(DashboardController))]
        [InlineData(typeof(ProductsController))]
        [InlineData(typeof(CategoriesController))]
        [InlineData(typeof(OrdersController))]
        public void AdminControllers_MustRequireAdminRole(Type controllerType)
        {
            var areaAttr = controllerType.GetCustomAttribute<AreaAttribute>();
            Assert.NotNull(areaAttr);
            Assert.Equal("Admin", areaAttr.RouteValue);

            var authAttr = controllerType.GetCustomAttribute<AuthorizeAttribute>();
            Assert.NotNull(authAttr);
            Assert.Equal("Admin", authAttr.Roles);
        }

        [Theory]
        [InlineData(typeof(CheckOutController))]
        [InlineData(typeof(OrderController))]
        public void CustomerProtectedControllers_MustRequireAuthentication(Type controllerType)
        {
            var authAttr = controllerType.GetCustomAttribute<AuthorizeAttribute>();
            Assert.NotNull(authAttr);
        }

        [Theory]
        [InlineData(typeof(CartController), nameof(CartController.AddToCart))]
        [InlineData(typeof(CartController), nameof(CartController.UpdateQuantity))]
        [InlineData(typeof(CartController), nameof(CartController.RemoveItem))]
        [InlineData(typeof(CheckOutController), nameof(CheckOutController.Index))]
        [InlineData(typeof(CategoriesController), nameof(CategoriesController.Create))]
        [InlineData(typeof(CategoriesController), nameof(CategoriesController.Edit))]
        [InlineData(typeof(CategoriesController), nameof(CategoriesController.DeleteConfirmed))]
        [InlineData(typeof(ProductsController), nameof(ProductsController.Create))]
        [InlineData(typeof(ProductsController), nameof(ProductsController.Edit))]
        [InlineData(typeof(ProductsController), nameof(ProductsController.DeleteConfirmed))]
        [InlineData(typeof(OrdersController), nameof(OrdersController.UpdateStatus))]
        public void MutatingPostActions_MustHaveValidateAntiForgeryToken(Type controllerType, string actionName)
        {
            var method = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == actionName && m.GetCustomAttribute<HttpPostAttribute>() != null);

            Assert.NotNull(method);

            var antiForgeryAttr = method.GetCustomAttribute<ValidateAntiForgeryTokenAttribute>();
            Assert.NotNull(antiForgeryAttr);
        }
    }
}
