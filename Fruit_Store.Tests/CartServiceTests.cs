using System.Text;
using Fruit_Store_MVC.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Fruit_Store.Tests
{
    public class CartServiceTests
    {
        private class MockSession : ISession
        {
            private readonly Dictionary<string, byte[]> _store = new();
            public bool IsAvailable => true;
            public string Id => "test-session";
            public IEnumerable<string> Keys => _store.Keys;

            public void Clear() => _store.Clear();
            public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
            public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
            public void Remove(string key) => _store.Remove(key);
            public void Set(string key, byte[] value) => _store[key] = value;
            public bool TryGetValue(string key, out byte[] value) => _store.TryGetValue(key, out value!);
        }

        private readonly CartService _cartService;
        private readonly MockSession _session;

        public CartServiceTests()
        {
            _session = new MockSession();
            var context = new DefaultHttpContext { Session = _session };
            var accessorMock = new Mock<IHttpContextAccessor>();
            accessorMock.Setup(a => a.HttpContext).Returns(context);

            _cartService = new CartService(accessorMock.Object);
        }

        [Fact]
        public void GetCart_WhenEmpty_ReturnsEmptyList()
        {
            var cart = _cartService.GetCart();
            Assert.NotNull(cart);
            Assert.Empty(cart);
        }

        [Fact]
        public void AddToCart_AddsNewItemCorrectly()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, "strawberry.jpg");

            var cart = _cartService.GetCart();
            Assert.Single(cart);
            Assert.Equal(1, cart[0].ProductId);
            Assert.Equal("Strawberry", cart[0].ProductName);
            Assert.Equal(4.50m, cart[0].UnitPrice);
            Assert.Equal(2, cart[0].Quantity);
            Assert.Equal(9.00m, cart[0].LineTotal);
        }

        [Fact]
        public void AddToCart_WhenItemExists_IncrementsQuantity()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, "strawberry.jpg");
            _cartService.AddToCart(1, "Strawberry", 4.50m, 3, "strawberry.jpg");

            var cart = _cartService.GetCart();
            Assert.Single(cart);
            Assert.Equal(5, cart[0].Quantity);
            Assert.Equal(22.50m, cart[0].LineTotal);
        }

        [Fact]
        public void UpdateQuantity_UpdatesExistingItemQuantity()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, "strawberry.jpg");
            _cartService.UpdateQuantity(1, 10);

            var cart = _cartService.GetCart();
            Assert.Single(cart);
            Assert.Equal(10, cart[0].Quantity);
        }

        [Fact]
        public void UpdateQuantity_WhenZeroOrNegative_RemovesItem()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, "strawberry.jpg");
            _cartService.UpdateQuantity(1, 0);

            var cart = _cartService.GetCart();
            Assert.Empty(cart);
        }

        [Fact]
        public void RemoveItem_RemovesOnlyTargetProduct()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, null);
            _cartService.AddToCart(2, "Grapes", 3.80m, 1, null);

            _cartService.RemoveItem(1);

            var cart = _cartService.GetCart();
            Assert.Single(cart);
            Assert.Equal(2, cart[0].ProductId);
        }

        [Fact]
        public void ClearCart_RemovesAllItems()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, null);
            _cartService.AddToCart(2, "Grapes", 3.80m, 1, null);

            _cartService.ClearCart();

            var cart = _cartService.GetCart();
            Assert.Empty(cart);
            Assert.Equal(0, _cartService.GetItemCount());
            Assert.Equal(0m, _cartService.GetSubtotal());
        }

        [Fact]
        public void GetSubtotal_CalculatesAccurateSumAcrossItems()
        {
            _cartService.AddToCart(1, "Strawberry", 4.50m, 2, null); // 9.00
            _cartService.AddToCart(2, "Grapes", 3.80m, 3, null);    // 11.40

            Assert.Equal(20.40m, _cartService.GetSubtotal());
            Assert.Equal(5, _cartService.GetItemCount());
        }
    }
}
