using System.ComponentModel.DataAnnotations;

namespace LocalBrands.Validation
{
    public class PhoneNumberValidationAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is string phoneNumber)
            {
                return !string.IsNullOrEmpty(phoneNumber)&&
                    System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^01\d{9}$");
            }
            return false;
        }
        public PhoneNumberValidationAttribute()
        {
            ErrorMessage = "Phone number must be exactly 11 digits and start with '01'";
        }
    }
}
