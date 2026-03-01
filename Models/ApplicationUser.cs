using Microsoft.AspNetCore.Identity;

namespace LocalBrands.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string City { get; set; }
        public virtual List<Review>? Reviews { get; set; }
        public virtual List<Cart>? Carts { get; set; }
    }
}
