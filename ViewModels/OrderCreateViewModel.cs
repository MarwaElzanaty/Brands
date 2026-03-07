using System.ComponentModel.DataAnnotations;

namespace LocalBrands.ViewModels
{
    public class OrderCreateViewModel
    {
        [Required(ErrorMessage = "Shipping address is required")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "Payment method is required")]
        public string PaymentMethod { get; set; }   // مثلاً: "CreditCard", "Wallet", "COD"

    }
}