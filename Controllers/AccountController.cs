using LocalBrands.Models;
using LocalBrands.Services.interfaces;
using LocalBrands.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalBrands.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IUserService userService,
                                 UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

       
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel, IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                string? uniqueFileName = UploadFile(ImageUrl);

                if (uniqueFileName != null)
                {
                    viewModel.ProfileUrl = uniqueFileName;
                }
                else
                {
                    ModelState.AddModelError("", "Image Upload Failed");
                    return View("Register", viewModel);
                }

                bool isAdmin = User.IsInRole("Admin");

                IdentityResult result = await _userService.RegisterUserAsync(viewModel, !isAdmin);

                if (result.Succeeded)
                {
                    if (isAdmin)
                        return RedirectToAction("Index", "Account");

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Register", viewModel);
            }

            return View("Register", viewModel);
        }

  

        public async Task<IActionResult> Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(viewModel, viewModel.RememberMe);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(viewModel.Email);

                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                        return RedirectToAction("Index", "Account");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password invalid");
                }
            }

            return View("Login", viewModel);
        }


        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutUserAsync();
            return RedirectToAction("Index", "Home");
        }


        [NonAction]
        public string? UploadFile(IFormFile ImageUrl)
        {
            string? uniqueFileName = null;

            if (ImageUrl != null && ImageUrl.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(),
                                                    "wwwroot/images/user");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" +
                                 Path.GetFileName(ImageUrl.FileName);

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImageUrl.CopyTo(fileStream);
                }

                return uniqueFileName;
            }

            return null;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index(string searchEmail, int pageNumber = 1, int pageSize = 3)
        {
            var users = _userService.GetAllUsers();

            if (!string.IsNullOrEmpty(searchEmail))
            {
                users = users
                    .Where(u => u.Email != null && u.Email.Contains(searchEmail, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var totalUsers = users.Count;

            var pagedUsers = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.SearchEmail = searchEmail;

            return View(pagedUsers);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel model, IFormFile? ImageUrl)
        {
            if (ImageUrl != null && ImageUrl.Length > 0)
            {
                string uniqueFileName = UploadFile(ImageUrl);
                if (!string.IsNullOrEmpty(uniqueFileName))
                {
                    model.ProfileUrl = uniqueFileName;
                }
                else
                {
                    ModelState.AddModelError("", "Image upload failed.");
                    return View("Edit", model);
                }
            }

            // If no new image uploaded, keep the old ProfileUrl (already bound from hidden input)
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details(string id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("There is no Account for this id");
            }
            return View(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ConfirmDelete(string Id)
        {
            var result = _userService.DeleteUserAsync(Id);
            if (result.Result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }
            
            return NotFound("There is no Account for this id");

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

    }
}