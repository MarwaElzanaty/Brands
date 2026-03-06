using LocalBrands.Data;
using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.Services.Implementation;
using LocalBrands.Services.interfaces;
using LocalBrands.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDB>();
builder.Services.AddDbContext<ApplicationDB>(optionbuilder =>
{
    optionbuilder.UseSqlServer(builder.Configuration.GetConnectionString("conString"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDB>();


builder.Services.AddScoped<IUserService, UserService>();


// custom services for Repositories :
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<ReviewRepo>();
builder.Services.AddScoped<BrandRepo>();

builder.Services.AddScoped<IProductRepo>(sp=>sp.GetRequiredService<ProductRepo>());
builder.Services.AddScoped<IRepository<Product>>(sp=>sp.GetRequiredService<ProductRepo>());
builder.Services.AddScoped<IReviewRepo>(sp => sp.GetRequiredService<ReviewRepo>());
builder.Services.AddScoped<IRepository<Review>>(sp => sp.GetRequiredService<ReviewRepo>());
builder.Services.AddScoped<IBrandRepo>(sp => sp.GetRequiredService<BrandRepo>());
builder.Services.AddScoped<IRepository<Brand>>(sp => sp.GetRequiredService<BrandRepo>());
builder.Services.AddScoped<IHomeService, HomeService>();

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
//builder.Services.AddScoped<IOrderRepo, OrderRepo>();
//builder.Services.AddScoped<ICartRepo, CartRepo>();
//builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();






//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
// Seed admin user and test password hash
SeedRolesAndAdminAsync(app).GetAwaiter().GetResult();
test();




app.Run();


static async Task SeedRolesAndAdminAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    // roles
    string[] roles = { "Admin", "User" };

    // make role
    foreach (var roleName in roles)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
            Console.WriteLine($"? Role '{roleName}' created successfully.");
        }
    }


    string adminEmail = "admin@example.com";
    string adminPassword = "Admin@123";
    string adminRole = "Admin";


    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdmin = new ApplicationUser
        {
            UserName = "Admin",
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            EmailConfirmed = true,
            Gender = Gender.Male,
            Address = "Admin Address",
            City = "Admin City",
            PhoneNumber = "01000000000",
            NationalId = "00000000000000",
            DateOfBrith = new DateOnly(1990, 1, 1)
        };

        var result = await userManager.CreateAsync(newAdmin, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, adminRole);
            Console.WriteLine("? Admin user created successfully.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"? Error creating admin user: {error.Description}");
            }
        }
    }
    else
    {
        Console.WriteLine("?? Admin user already exists.");
    }
}
static void test()
{
    var hasher = new PasswordHasher<IdentityUser>();
    var user = new IdentityUser();
    string passwordHash = hasher.HashPassword(user, "Admin@123");
    Console.WriteLine(passwordHash);
}
