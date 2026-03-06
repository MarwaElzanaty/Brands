using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LocalBrands.Models;
using LocalBrands.Validation;

namespace LocalBrands.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm Passwortd Must Match Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="First Name Is Required")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="FirstName Must  Be Between 2 and 50 Characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name Is Required")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="LastName Must Be Between 2 And 50")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Gender")]
        [Required(ErrorMessage ="please select the gender")]
        public Gender Gender { get; set; }
        [Url(ErrorMessage ="Invaild Url Format")]
        [DisplayName("Profile Picture")]
        public string? ProfileUrl { get; set; }
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [StringLength(100,ErrorMessage ="City name cannot exceessed 100 charchteres")]
        [DisplayName("City")]
        public string City { get; set; }
        [PhoneNumberValidation(ErrorMessage ="phone nmber must start with \"01\" in addition to having 11 digitis. ")]
        [DisplayName("Phone Number")]     
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="National ID is required")]
        [RegularExpression(@"^\d{14}$",ErrorMessage ="National ID must be excately 14 digitis")]
        [DisplayName("National ID")]
        public string NationalId { get; set; }
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth {  get; set; }

    }
}
