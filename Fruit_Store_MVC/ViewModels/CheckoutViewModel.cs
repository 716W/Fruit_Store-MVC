using System.ComponentModel.DataAnnotations;
using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.ViewModels
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        // Read-only cart summary populated by controller
        public List<CartItem> CartItems { get; set; } = new();
        public decimal Subtotal => CartItems.Sum(c => c.LineTotal);
    }
}
