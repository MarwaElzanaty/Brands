using LocalBrands.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LocalBrands.Services.interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model, bool autoSignIn);
        Task<SignInResult> LoginUserAsync(LoginViewModel model, bool rememberme);
        Task SignOutUserAsync();
        EditProfileViewModel GetUserById(string userId);
        Task<IdentityResult> UpdateUserAsync(EditProfileViewModel model);
        Task<IdentityResult> DeleteUserAsync(string userId);
        List<EditProfileViewModel> GetAllUsers();

        UserProfileViewModel GetUserProfileById(string userId);
        Task<IdentityResult> UpdateUserProfileAsync(UserProfileViewModel model);
        Task<IdentityResult> UpdateUserProfilePersonalInfo(PersonalInformation model);
        Task<IdentityResult> UpdateUserProfileAccountInfo(AccountInformation model, string userId);
    }
}
