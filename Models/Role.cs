using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Pkcs;

namespace LocalBrands.Models
{
    public class Role:IdentityRole
    {
        public string RoleName { get; set; }
    }
}
