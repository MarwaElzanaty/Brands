using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace LocalBrands.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="Email Is Required")]
        [EmailAddress (ErrorMessage ="Invalid Email Adress")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType (DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
        public IEnumerable<AuthenticationScheme> Schemes { get; set; } = new List<AuthenticationScheme>();
    }
}
